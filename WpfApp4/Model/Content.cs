using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.ViewModel;

namespace WpfApp4.Model
{
    public class Content
    {
        public ObservableCollection<FileSystemEntry> Scan(string path)
        {
            ObservableCollection<FileSystemEntry> FileSystemEntries = new ObservableCollection<FileSystemEntry>();
            foreach (var dir in Directory.EnumerateDirectories(path))
            {
                try
                {
                    FileSystemEntries.Add(new FileSystemEntry(Path.GetFileName(dir), Scan(dir)));
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (IOException)
                {
                    continue;
                }
            }
            foreach (var file in Directory.EnumerateFiles(path))
            {
                try
                {
                    FileSystemEntries.Add(new FileSystemEntry(Path.GetFileName(file)));
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (IOException)
                {
                    continue;
                }
            }
            return FileSystemEntries;
        }
        public async Task<ObservableCollection<FileSystemEntry>> ScanAsync(string path)
        {
            return await Task.Run(() => Scan(path));
        }
        
    }
}
