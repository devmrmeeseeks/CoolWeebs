﻿using CoolWeebs.API.Common.Repository;
using CoolWeebs.API.Database;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Repositories
{
    public class TitleRepository : BaseRepository<TitleEntity, long>, ITitleRepository
    {
        public TitleRepository(BaseContext context) : base(context)
        {
        }
    }
}
