using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Model;

namespace WpfApp4.ViewModel
{
    public class FileSystemEntry :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            } 
        }
        public async Task<ObservableCollection<FileSystemEntry>> GetTree(string path)
        {
            Content content = new Content();
            FileSystemEntries = await content.ScanAsync(path);
            return FileSystemEntries;
        }
        public ObservableCollection<FileSystemEntry> fileSystemEntries;
        public ObservableCollection<FileSystemEntry> FileSystemEntries
        {
            get
            {
                return fileSystemEntries;
            }
            set
            {
                fileSystemEntries = value;
                OnPropertyChanged("FileSystemEntries");
            }
        }
        public ObservableCollection<FileSystemEntry> children;
        public ObservableCollection<FileSystemEntry> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }

        public FileSystemEntry(string name, ObservableCollection<FileSystemEntry> children)
        {
            Name = name;
            Children = children;
        }
        public FileSystemEntry(string name)
        {
            Name = name;
        }
        public FileSystemEntry()
        {

        }
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
