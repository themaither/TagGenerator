using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TagGenerator.Model;
public class SerlializedTagGroupProvider : ITagGroupProvider
{
    public string Path { get; set; }

    public IEnumerable<TagGroup> GetTagGroups()
    {
        IEnumerable<TagGroup>? enumerable = GetFromFile(Path);
        if (enumerable is null)
        {
            return new List<TagGroup>();
        }
        return enumerable;
    }

    public IEnumerable<TagGroup>? GetFromFile(string filePath)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText(filePath));
        TagGroupsFile? tagGroupsFile = JsonSerializer.Deserialize<TagGroupsFile>(jsonDocument);

        if (tagGroupsFile is not null)
        {
            return tagGroupsFile.TagGroups;
        }
        return null;
    }
}

[Serializable]
[JsonSerializable(typeof(TagGroupsFile))]

public sealed class TagGroupsFile
{
    public TagGroupsFile(IEnumerable<TagGroup> tagGroups)
    {
        TagGroups = tagGroups;
    }

    public IEnumerable<TagGroup> TagGroups { get; set; }
}
