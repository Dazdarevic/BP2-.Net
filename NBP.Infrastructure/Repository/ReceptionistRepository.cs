using Microsoft.EntityFrameworkCore;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;
using NBP.Domain.Entities;
using NBP.Domain.Identity;
using NBP.Infrastructure.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace NBP.Infrastructure.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly DataContext dc;

        public ReceptionistRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await dc.Members.ToListAsync();
        }

        public async Task<bool> CreateRegistrationRequestAsync(RegistrationRequest request)
        {
            //enkriptuj password
            try
            {
                bool emailExists = await EmailExistsAsync(request?.Email);
                if (emailExists)
                {
                    return false;
                }
                request.Password = EncryptPassword(request.Password);

                dc.RegistrationRequests.Add(request);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //ne oslanja se na stanje objekta, vec na ulazne parametre
       
            public static string EncryptPassword(string password)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // Pretvori lozinku u bajtovni niz
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    // Konvertuj bajtove u string u heksadecimalnom formatu
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        

        public async Task<IEnumerable<RegistrationRequest>> GetAllRequestsAsync()
        {
            var requests = await dc.RegistrationRequests.ToListAsync();
            return requests;
        }

        public async Task<bool> ApproveRegistrationRequestAsync(int requestId)
        {
            var request = await dc.RegistrationRequests.FindAsync(requestId);

            if (request != null)
            {
                try
                {
                    if (request.Role == "trainer")
                    {
                        var newUser = new TrainerUser
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            BirthDate = request.BirthDate,
                            UserName = request.UserName,
                            Email = request.Email,
                            Role = request.Role,
                            PhoneNumber = request.PhoneNumber,
                            Password = request.Password,
                            RegistrationDate = DateTime.Now
                        };

                        // Dodaj novog korisnika u odgovarajući DbSet
                        dc.Trainers.Add((TrainerUser)newUser);

                        dc.RegistrationRequests.Remove(request);

                        return true;
                    }
                    if (request.Role == "member")
                    {
                        var newUser = new Member
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            BirthDate = request.BirthDate,
                            UserName = request.UserName,
                            Email = request.Email,
                            Role = request.Role,
                            PhoneNumber = request.PhoneNumber,
                            Password = request.Password,
                            RegistrationDate = DateTime.Now
                        };

                        // Dodaj novog korisnika u odgovarajući DbSet
                        dc.Members.Add((Member)newUser);

                        dc.RegistrationRequests.Remove(request);

                        return true;
                    }

                    if (request.Role == "seller")
                    {
                        var newUser = new Seller
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            BirthDate = request.BirthDate,
                            UserName = request.UserName,
                            Email = request.Email,
                            Role = request.Role,
                            PhoneNumber = request.PhoneNumber,
                            Password = request.Password,
                            RegistrationDate = DateTime.Now
                        };

                        // Dodaj novog korisnika u odgovarajući DbSet
                        dc.Sellers.Add((Seller)newUser);

                        dc.RegistrationRequests.Remove(request);

                        return true;
                    }

                    if (request.Role == "sponsor")
                    {
                        var newUser = new Sponsor
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            BirthDate = request.BirthDate,
                            UserName = request.UserName,
                            Email = request.Email,
                            Role = request.Role,
                            PhoneNumber = request.PhoneNumber,
                            Password = request.Password,
                            RegistrationDate = DateTime.Now
                        };

                        // Dodaj novog korisnika u odgovarajući DbSet
                        dc.Sponsors.Add((Sponsor)newUser);

                        dc.RegistrationRequests.Remove(request);

                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while saving changes: {ex}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException}");
                    }
                }
            }

            return false;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await dc.Trainers.AnyAsync(t => t.Email == email) ||
                   await dc.Members.AnyAsync(m => m.Email == email) ||
                   await dc.Sellers.AnyAsync(s => s.Email == email) ||
                   await dc.Sponsors.AnyAsync(s => s.Email == email);
        }

        public async Task<bool> DeleteRequestAsync(int requestId)
        {
            try
            {
                var request = await dc.RegistrationRequests.FindAsync(requestId);

                if (request != null)
                {
                    dc.RegistrationRequests.Remove(request);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreatePaymentAsync(Payment payment)
        {
            try
            {
                dc.Payments.Add(payment);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating payment: {ex}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException}");
                }
                return false;
            }
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            return await dc.Payments
                .Select(p => new PaymentDto
                {
                    memberName = p.memberName, 
                    paymentId = p.paymentId, 
                    Date = p.Date 
                })
                .ToListAsync();
        }


    }
}
