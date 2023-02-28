using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TagGenerator.Model;

namespace TagGenerator.ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public MainWindowViewModel()
    {
        // _tagGroupProvider = new ExampleTagGroupProvider();
        _tagGroupProvider = new SerlializedTagGroupProvider() { Path = "C:\\Users\\Admin\\Desktop\\tags.json" };
        _path = "";
        _generatedTags = "";
        TagGroups = new ObservableCollection<TagGroup>();
        UsedTagGroups = new ObservableCollection<TagGroup>();
        Tags = new ObservableCollection<string>();
        AddTagGroupCommand = new DelegateCommand((item) => AddTagGroup(item));
        UpdateTagGroupsCommand = new DelegateCommand((_) => UpdateTagGroups());
        RemoveTagGroupCommand = new DelegateCommand((item) => RemoveTagGroup(item));
        OpenFileCommand = new DelegateCommand((_) => OpenFile());
        GenerateTagsCommand = new DelegateCommand((_) => GenerateTags());
    }

    private SerlializedTagGroupProvider _tagGroupProvider;

    private TagGroup? _selectedTagGroup;

    private string _path;
    private string _generatedTags;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<TagGroup> TagGroups { get; }

    public ObservableCollection<TagGroup> UsedTagGroups { get; }

    public string GeneratedTags 
    {
        get => _generatedTags;
        set
        {
            _generatedTags = value;
            OnPropertyChanged("GeneratedTags");
        }
    }

    public string Path
    {
        get => _path;
        set
        {
            _path = value;
            OnPropertyChanged("Path");
        }
    }

    public TagGroup? SelectedTagGroup
    {
        get => _selectedTagGroup;
        set
        {
            _selectedTagGroup = value;
            OnPropertyChanged("SelecrtedTagGroup");
        }
    }

    public ObservableCollection<string> Tags { get; }

    public DelegateCommand AddTagGroupCommand { get; }

    public DelegateCommand UpdateTagGroupsCommand { get; }

    public DelegateCommand RemoveTagGroupCommand { get; }

    public DelegateCommand OpenFileCommand { get; }

    public DelegateCommand GenerateTagsCommand { get; }

    public void AddTagGroup(object? item)
    {
        if (item is TagGroup tagGroup && !UsedTagGroups.Contains(tagGroup))
        {
            UsedTagGroups.Add(tagGroup);
        }
    }

    public void UpdateTagGroups()
    {
        if (!File.Exists(Path))
        {
            return;
        }
        TagGroups.Clear();
        UsedTagGroups.Clear();
        _tagGroupProvider.Path = Path;
        IEnumerable<TagGroup> tagGroups = _tagGroupProvider.GetTagGroups();
        foreach (var tagGroup in tagGroups)
        {
            TagGroups.Add(tagGroup);
        }
    }

    public void OpenFile()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.ShowDialog();
        Path = openFileDialog.FileName;
        UpdateTagGroups();
    }

    public void RemoveTagGroup(object? item)
    {
        if (item is TagGroup tagGroup && UsedTagGroups.Contains(tagGroup))
        {
            UsedTagGroups.Remove(tagGroup);
        }
    }

    public void GenerateTags()
    {
        List<string> tags = new List<string>();
        foreach (var tagGroup in UsedTagGroups)
        {
            tags.AddRange(tagGroup.Tags);
        }
        GeneratedTags = String.Join(",", tags);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
