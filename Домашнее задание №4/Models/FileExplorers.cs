using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace Домашнее_задание__4.Class
{
    public interface IExplorer
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string IconPath { get; set; }
        public Bitmap? IconBitmap
        {
            get => new(AssetLoader.Open(new Uri(IconPath)));
        }
    }


    public class Directoryies : IExplorer
    {
        public Directoryies()
        {
            Name = string.Empty;
            IconPath = "avares://Домашнее задание №4/Assets/folder.png";
            Path = string.Empty;
        }

        public Directoryies(string path, string name)
        {
            Name = name;
            Path = path;
            IconPath = "avares://Домашнее задание №4/Assets/folder.png";
        }

        public string Name { get; set; }
        public string Path { get; set; }

        public string IconPath { get; set; }

        public Bitmap? IconBitmap
        {
            get => new(AssetLoader.Open(new Uri(IconPath)));
        }
    }
    public class File : IExplorer
    {
        public File()
        {
            Name = string.Empty;
            IconPath = "avares://Домашнее задание №4/Assets/file.png";
            Path = string.Empty;
        }

        public File(string path, string name)
        {
            Name = name;
            Path = path;
            IconPath = "avares://Домашнее задание №4/Assets/file.png";
        }

        public string Name { get; set; }
        public string Path { get; set; }

        public string IconPath { get; set; }

        public Bitmap? IconBitmap
        {
            get => new(AssetLoader.Open(new Uri(IconPath)));
        }
    }

    public class Drive : Directoryies
    {
        public Drive()
        {
            Name = string.Empty;
            Path = string.Empty;
            IconPath = "avares://Домашнее задание №4/Assets/hard.png";
        }

        public Drive(string path, string name)
        {
            Name = name;
            Path = path;
            IconPath = "avares://Домашнее задание №4/Assets/hard.png";
        }

    }
}

