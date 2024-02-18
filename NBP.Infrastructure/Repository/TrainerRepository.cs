using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using NBP.Domain.Entities;
using NBP.Infrastructure.Data;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;

namespace NBP.Infrastructure.Repository
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DataContext dc;

        public TrainerRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<Domain.Identity.Member>> GetAllMembersAsync()
        {
            var members = await dc.Members.ToListAsync();

            return members;
        }

        public async Task<IEnumerable<MemberInfoDto>> GetAllMembersByManager()
        {
            var members = await dc.Members.ToListAsync();

            var membersInfo = new List<MemberInfoDto>();

            foreach (var member in members)
            {
                // Dohvatanje podataka o treneru za svakog člana
                var trainer = await dc.Trainers.FindAsync(member.SelectedTrainerId);
                var membership = await dc.Memberships.FindAsync(member.ID);


                var memberInfo = new MemberInfoDto
                {
                    Id = member.ID,
                    FirstName = member?.FirstName,
                    LastName = member?.LastName,
                    Email = member.Email,
                    TrainerFirstName = trainer?.FirstName ?? "NN",
                    TrainerLastName = trainer?.LastName ?? "NN",

                    MembershipId = membership?.IdMembership ?? 0,
                    MembershipAmount = membership?.MembershipAmount ?? "N/A"
                };

                membersInfo.Add(memberInfo);
            }

            return membersInfo;
        }
        public async Task<IEnumerable<Domain.Identity.Member>> GetMembersWithSelectedTrainerAsync(int trainerId)
        {
            var membersWithSelectedTrainer = await dc.Members
                .Where(member => member.SelectedTrainerId == trainerId)
                .ToListAsync();

            return membersWithSelectedTrainer;
        }

        public async Task<bool> AddOrUpdateCommentAsync(CommentDto comment)
        {
            var existingComment = await dc.Comments.FindAsync(comment.Id);

            if (existingComment != null)
            {
                existingComment.Text = comment.Text;

            }
            else
            {
                var newComment = new Comment
                {
                    Text = comment.Text,
                    MemberId = comment.MemberId,
                    TrainerId = comment.TrainerId
                };

                dc.Comments.Add(newComment);
            }

            try
            {
                await dc.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<CommentDto> GetCommentByTrainerAndMemberIdAsync(int trainerId, int memberId)
        {
            var comment = await dc.Comments
                .FirstOrDefaultAsync(c => c.TrainerId == trainerId && c.MemberId == memberId);

            if (comment == null)
            {
                // komentar ne postoji
                return null;
            }

            var commentDto = new CommentDto
            {
                Id = comment.Id,
                TrainerId = comment.TrainerId,
                MemberId = comment.MemberId,
                Text = comment.Text
            };

            return commentDto;
        }

        public async Task<CommentDto> GetCommentByMemberIdAsync(int memberId)
        {
            var comment = await dc.Comments
                .FirstOrDefaultAsync(c => c.MemberId == memberId);

            if (comment == null)
            {
                // komentar ne postoji
                return null;
            }

            var commentDto = new CommentDto
            {
                Id = comment.Id,
                TrainerId = comment.TrainerId,
                MemberId = comment.MemberId,
                Text = comment.Text
            };

            return commentDto;
        }

    }
}
