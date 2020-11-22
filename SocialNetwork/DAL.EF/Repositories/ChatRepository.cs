using DAL.Domain;
using DAL.EF.Contexts;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.EF.Repositories
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(ApplicationDbContext context) : base(context)
        {
        }

        protected override IQueryable<Chat> DbSetWithAllProperties()
        {
            return DbSet;
        }
    }
}
