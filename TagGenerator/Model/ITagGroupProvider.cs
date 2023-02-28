using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagGenerator.Model;

public interface ITagGroupProvider
{
    public IEnumerable<TagGroup> GetTagGroups();
}
