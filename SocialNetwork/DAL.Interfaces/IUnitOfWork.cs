﻿using DAL.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IFriendshipRepository Friendship { get; }
        IMessageRepository Message { get; } 
        Task SaveChangesAsync();
    }
}