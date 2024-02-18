using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;
using NBP.Domain.Entities;
using NBP.Domain.Identity;
using NBP.Infrastructure.Data;

namespace NBP.Infrastructure.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext dc;

        public MemberRepository(DataContext dc)
        {
            this.dc = dc;
        }


        //public async Task<IEnumerable<TrainerUser>> SortTrainersAsync(string sortByField)
        //{
        //    if (sortByField == "firstName")
        //    {
        //        return await dc.Trainers.OrderBy(t => t.FirstName).ToListAsync();
        //    }
        //    else if (sortByField == "lastName")
        //    {
        //        return await dc.Trainers.OrderBy(t => t.LastName).ToListAsync();
        //    }
        //    return null;
        //}


        public async Task<IEnumerable<TrainerUser>> SortTrainersAsync(string sortByField, int page, int pageSize)
        {
            if (sortByField == "firstName")
            {
                return await dc.Trainers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(t => t.FirstName)
                .ToListAsync();
            }
            else if (sortByField == "lastName")
            {
                return await dc.Trainers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(t => t.LastName)
                .ToListAsync();
            }
            return null;
        }
        public async Task<bool> ChooseTrainer(int memberId, int trainerId)
        {
            var member = await dc.Members.FindAsync(memberId);
            if (member != null && member.SelectedTrainerId == null)
            {
                member.SelectedTrainerId = trainerId;
                return true;
            }
            return false;
        }


        public async Task<bool> ResetSelectedTrainer(int memberId)
        {
            var member = await dc.Members.FindAsync(memberId);
            if (member != null)
            {
                member.SelectedTrainerId = null;
                return true;
            }
            return false;
        }

        public async Task<bool> CheckRating(int memberId, int trainerId)
        {
            var rating = await dc.Ratings.FirstOrDefaultAsync(r => r.MemberId == memberId && r.TrainerId == trainerId);

            return rating != null;
        }

        public async Task<IEnumerable<Membership>> GetMembershipsForMemberAsync(int memberId)
        {
            return await dc.Memberships.Where(m => m.ID == memberId).ToListAsync();
        }

        public async Task<IEnumerable<TrainerUser>> GetAllTrainersAsync()
        {
            return await dc.Trainers.ToListAsync();
        }

        public async Task<Member> GetMember(int memberId)
        {
            var member = await dc.Members.FindAsync(memberId);
#pragma warning disable CS8603 // Possible null reference return.
            return member;
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<TrainerUser> GetTrainer(int trainerId)
        {
            var trainer = await dc.Trainers.FindAsync(trainerId);

#pragma warning disable CS8603 // Possible null reference return.
            return trainer;
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<bool> ExtendMembershipAsync(int memberId, string newMembershipAmount, int targetMonth)
        {
            var member = await dc.Memberships.FindAsync(memberId);

            if (member != null && targetMonth > DateTime.Now.Month) // Provera da li se produžava za naredni mesec
            {
                // Update membership details
                member.MembershipAmount = newMembershipAmount;
                member.Month = targetMonth;

                return true;
            }

            return false;
        }

        public async Task<bool> RateTrainerAsync(int memberId, int trainerId, int ratingValue)
        {
            var member = await dc.Members.FindAsync(memberId);
            var trainer = await dc.Trainers.FindAsync(trainerId);

            if (member != null && trainer != null && ratingValue >= 1 && ratingValue <= 5)
            {
                var rating = new Rating
                {
                    Value = ratingValue,
                    MemberId = memberId,
                    TrainerId = trainerId
                };

                dc.Ratings.Add(rating);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Comment>> GetMemberCommentsAsync(int memberId)
        {
            var comments = await dc.Comments
                .Where(comment => comment.MemberId == memberId)
                .ToListAsync();

            return comments;
        }

        public async Task<bool> HasSelectedTrainer(int memberId)
        {
            var member = await dc.Members.FindAsync(memberId);

            if (member != null && member.SelectedTrainerId.HasValue && member.SelectedTrainerId != -1)
            {
                return true;
            }

            return false;
        }


        public async Task<double> GetAverageRatingByTrainerId(int trainerId)
        {
            double averageRating = await dc.Ratings
                .Where(r => r.TrainerId == trainerId)
                .AverageAsync(r => r.Value);

            return averageRating;

        }

        public async Task<IEnumerable<TrainerUser>> GetPaginatedTrainersAsync(int page, int pageSize, int id)
        {
            var trainers = await dc.Trainers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


                int totalNumber = page * pageSize - pageSize;

                var t = await dc.Trainers!.Skip(totalNumber).Take(pageSize).ToListAsync();
                return t;
            
            //return trainers;
        }


        public async Task<IEnumerable<PaymentDto>> GetPaymentsForMemberAsync(string userName)
        {
            return await dc.Payments
                .Where(p => p.memberName == userName || p.memberName == userName.ToLower())
                .Select(p => new PaymentDto
                {
                    paymentId = p.paymentId,
                    Date = p.Date,
                    memberName = p.memberName
                })
                .ToListAsync(); ;
        }
        //sortiranje
        public async Task<ActionResult<object>> SortPagTrainersAsync(int page = 1, int pageSize = 10, string sortBy = "id")
        {
            var query = dc.Trainers.AsQueryable();

            // Paginacija
            var paginatedQuery = query.Skip((page - 1) * pageSize).Take(pageSize);

            // Sortiranje podataka samo na određenoj stranici
            switch (sortBy)
            {
                case "firstName":
                    paginatedQuery = paginatedQuery.OrderBy(trainer => trainer.FirstName);
                    break;
                case "lastName":
                    paginatedQuery = paginatedQuery.OrderBy(trainer => trainer.LastName);
                    break;
                default:
                    paginatedQuery = paginatedQuery.OrderBy(trainer => trainer.ID);
                    break;
            }

            // Ukupan broj zapisa za cijeli skup podataka (neophodan za izračunavanje ukupnog broja stranica)
            var totalCount = await query.CountAsync();

            // Ukupan broj stranica (uzimajući u obzir paginaciju)
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // Izvršite upit i dobijte podatke za trenere na određenoj stranici, koji su sortirani
            var trainers = await paginatedQuery.ToListAsync();

            // Kreirajte rezultat koji će sadržati informacije o paginaciji, sortiranju i podacima o trenerima
            var result = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Trainers = trainers
            };

            // Vratite rezultat
            return result;
        }


        //paginacija
        public async Task<ActionResult<object>> GetPagTrainersAsync(int page = 1, int pageSize = 10)
        {
            var query = dc.Trainers.AsQueryable();


            var totalCount = dc.Trainers.AsQueryable().Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var result = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Trainers = dc.Trainers.AsQueryable()

            };

            return result;
        }
        //filtriranje
        public async Task<ActionResult<object>> GetFiltredTrainerAsync(int page = 1, int pageSize = 10, string filter="")
        {
            var query = dc.Trainers.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(trainer => trainer.FirstName.Contains(filter) || trainer.LastName.Contains(filter));
            }

            var totalCount = dc.Trainers.AsQueryable().Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var trainers = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var result = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Trainers = trainers

            };

            return result;
        }

    }
}
