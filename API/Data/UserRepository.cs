using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
    {
        public async Task<AppUser?> GetAppUserByUsername(string username)
        {
            return await context.Users
            .Include(x => x.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<MemberDto?> GetMemberAsync(string username)
        {
            return await context.Users
              .Where(x => x.UserName == username)
              .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
              .SingleOrDefaultAsync();
        }


        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await context.Users
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();
        }


        public async Task<MemberDto?> GetUserById(int id)
        {
            return await context.Users
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await context.Users.Include(x => x.Photos).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}