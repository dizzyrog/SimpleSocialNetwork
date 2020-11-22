using DAL.EF.Contexts;
using DAL.EF.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IFriendshipRepository Friendship { get; }
        public  IChatRepository Chat { get; }
        public IMessageRepository Message { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Friendship = new FriendshipRepository(_context);
            Chat = new ChatRepository(_context);
            Message = new MessageRepository(_context);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

