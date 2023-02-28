using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagGenerator.Model;
public class ExampleTagGroupProvider : ITagGroupProvider
{
    public IEnumerable<TagGroup> GetTagGroups()
    {
        yield return new TagGroup
        {
            Label = "Example tag 1",
            Tags = new List<string>()
            {
                "Tag 1.1", "Tag 1.2", "Tag 1.3"
            }
        };
        yield return new TagGroup
        {
            Label = "Example tag 2",
            Tags = new List<string>()
            {
                "Tag 2.1", "Tag 2.2", "Tag 2.3", "Tag 2.4"
            }
        };
    }
}
