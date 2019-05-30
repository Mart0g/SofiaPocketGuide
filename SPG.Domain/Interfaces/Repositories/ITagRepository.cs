using SPG.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace SPG.Domain.Interfaces.Repositories
{
    public interface ITagRepository: IDisposable, IBaseRepository<TagEntity>
    {
        List<string> CheckWordInTags(string word);
        List<string> CheckWordWithMorphemes(string word);
    }
}
