using Microsoft.EntityFrameworkCore;
using NBP.Domain.Entities;
using NBP.Infrastructure.Data;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;

namespace NBP.Infrastructure.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly DataContext dc;

        public ManagerRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<TrainerWithSalaryDto>> GetAllTrainersWithSalariesAsync()
        {
            return await dc.Trainers
                .GroupJoin(
                    dc.TrainerSalaries,
                    trainer => trainer.ID,
                    salary => salary.IdSalary,
                    (trainer, salaries) => new { trainer, salaries }
                )
                .SelectMany(
                    x => x.salaries.DefaultIfEmpty(),
                    (x, salary) => new TrainerWithSalaryDto
                    {
                        ID = x.trainer.ID,
                        FirstName = x.trainer.FirstName,
                        LastName = x.trainer.LastName,
                        SalaryAmount = salary != null ? salary.SalaryAmount : "N/A"
                    }
                )
                .ToListAsync();
        }


        public async Task AddOrUpdateTrainerSalaryAsync(int trainerId, string salaryAmount)
        {
            var existingSalary = await dc.TrainerSalaries.FindAsync(trainerId);

            if (existingSalary != null)
            {
                // Ažuriranje postojeće plate
                existingSalary.SalaryAmount = salaryAmount;
            }
            else
            {
                // Kreiranje novog unosa ako ne postoji
                var newTrainerSalary = new TrainerSalary
                {
                    ID = trainerId,
                    SalaryAmount = salaryAmount
                };
                dc.TrainerSalaries.Add(newTrainerSalary);
            }

            await dc.SaveChangesAsync();
        }


        public async Task AddMembershipAmount(int memberId, string membershipAmount)
        {
            var member = await dc.Memberships.FindAsync(memberId);
            if (member != null)
            {
                member.MembershipAmount = membershipAmount;

            }
            else
            {
                var membership = new Membership
                {
                    ID = memberId,
                    MembershipAmount = membershipAmount
                };

                dc.Memberships.Add(membership);
            }

            await dc.SaveChangesAsync();

        }

        public async Task<int> GetTrainerIdOccurrenceAsync(int trainerId)
        {
            int numberOfMembers = await dc.Members.CountAsync(m => m.SelectedTrainerId == trainerId);
            return numberOfMembers;
        }

    }
}
