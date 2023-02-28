# TagGenerator

Generate tags for your YouTube video more easily.

Before you can automate creation of your video tags, you need to create or get somewhere a tag list. It is a basic JSON file that looks like this:

```json
{
    "TagGroups": [
        {
            "Label": "My tag group",
            "Tags": [ "Tag 1", "Tag 2", "Tag 3" ]
        }
    ]
}
```

Someday I will add an ui tool for this.

## Build details

Use [Visual studio 2022](visualstudio.microsoft.com) to build solution