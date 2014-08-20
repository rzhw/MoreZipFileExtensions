using MoreZipFileExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoreZipFileExtensions.Tests
{
    public class CreateEntryFromFolderTests
    {
        [Fact]
        public void CanAddEmptyFolder()
        {
            string tempDir = GetTempDir();
            string newZipPath = Path.Combine(tempDir, "test.zip");

            string newDirName = "wat";
            string newDirPath = Path.Combine(tempDir, newDirName);
            Directory.CreateDirectory(newDirPath);

            using (var stream = new FileStream(newZipPath, FileMode.Create))
                using (var zip = new ZipArchive(stream, ZipArchiveMode.Create))
                    zip.CreateEntryFromFolder(newDirPath, newDirName);
            
            using (var stream = new FileStream(newZipPath, FileMode.Open))
                using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
                    Assert.NotNull(zip.GetEntry(newDirName + "/"));
        }

        [Fact]
        public void CanAddFolderWithFile()
        {
            string tempDir = GetTempDir();
            string newZipPath = Path.Combine(tempDir, "test.zip");

            string newDirName = "wat";
            string newDirPath = Path.Combine(tempDir, newDirName);
            Directory.CreateDirectory(newDirPath);

            string newDirNewFile1Name = "test1.txt";
            string newDirNewFile1Path = Path.Combine(newDirPath, newDirNewFile1Name);
            File.WriteAllText(newDirNewFile1Path, "i have no idea what i'm doing");

            using (var stream = new FileStream(newZipPath, FileMode.Create))
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Create))
                zip.CreateEntryFromFolder(newDirPath, newDirName);

            using (var stream = new FileStream(newZipPath, FileMode.Open))
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                Assert.NotNull(zip.GetEntry(newDirName + "/"));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewFile1Name));
            }
        }

        [Fact]
        public void CanAddFolderWithFiles()
        {
            string tempDir = GetTempDir();
            string newZipPath = Path.Combine(tempDir, "test.zip");

            string newDirName = "wat";
            string newDirPath = Path.Combine(tempDir, newDirName);
            Directory.CreateDirectory(newDirPath);

            string newDirNewFile1Name = "test1.txt";
            string newDirNewFile1Path = Path.Combine(newDirPath, newDirNewFile1Name);
            File.WriteAllText(newDirNewFile1Path, "i have no idea what i'm doing");

            string newDirNewFile2Name = "test2.txt";
            string newDirNewFile2Path = Path.Combine(newDirPath, newDirNewFile2Name);
            File.WriteAllText(newDirNewFile2Path, "pls halp");

            using (var stream = new FileStream(newZipPath, FileMode.Create))
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Create))
                zip.CreateEntryFromFolder(newDirPath, newDirName);

            using (var stream = new FileStream(newZipPath, FileMode.Open))
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                Assert.NotNull(zip.GetEntry(newDirName + "/"));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewFile1Name));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewFile2Name));
            }
        }

        [Fact]
        public void CanAddFolderWithFilesAndFolders()
        {
            string tempDir = GetTempDir();
            string newZipPath = Path.Combine(tempDir, "test.zip");

            string newDirName = "wat";
            string newDirPath = Path.Combine(tempDir, newDirName);
            Directory.CreateDirectory(newDirPath);

            string newDirNewFile1Name = "test1.txt";
            string newDirNewFile1Path = Path.Combine(newDirPath, newDirNewFile1Name);
            File.WriteAllText(newDirNewFile1Path, "i have no idea what i'm doing");

            string newDirNewFile2Name = "test2.txt";
            string newDirNewFile2Path = Path.Combine(newDirPath, newDirNewFile2Name);
            File.WriteAllText(newDirNewFile2Path, "pls halp");

            string newDirNewDir1Name = "test3";
            string newDirNewDir1Path = Path.Combine(newDirPath, newDirNewDir1Name);
            Directory.CreateDirectory(newDirNewDir1Path);

            string newDirNewDir2Name = "test4";
            string newDirNewDir2Path = Path.Combine(newDirPath, newDirNewDir2Name);
            Directory.CreateDirectory(newDirNewDir2Path);

            string newDirNewDir2NewFile1Name = "test5.txt";
            string newDirNewDir2NewFile1Path = Path.Combine(newDirNewDir2Path, newDirNewDir2NewFile1Name);
            File.WriteAllText(newDirNewDir2NewFile1Path, "i crie evertim");

            using (var stream = new FileStream(newZipPath, FileMode.Create))
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Create))
                zip.CreateEntryFromFolder(newDirPath, newDirName);

            using (var stream = new FileStream(newZipPath, FileMode.Open))
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                Assert.NotNull(zip.GetEntry(newDirName + "/"));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewFile1Name));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewFile2Name));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewDir1Name + "/"));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewDir2Name + "/"));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewDir2Name + "/" + newDirNewDir2NewFile1Name));
            }
        }

        [Fact]
        public void CanAddFoldersWithFilesAndFolders()
        {
            string tempDir = GetTempDir();
            string newZipPath = Path.Combine(tempDir, "test.zip");

            string newDirName = "wat";
            string newDirPath = Path.Combine(tempDir, newDirName);
            Directory.CreateDirectory(newDirPath);
            string newDirName2 = "watwat";
            string newDir2Name = "gonna pop some tags";
            string newDir2Path = Path.Combine(tempDir, newDir2Name);
            Directory.CreateDirectory(newDir2Path);

            string newDirNewFile1Name = "test1.txt";
            string newDirNewFile1Path = Path.Combine(newDirPath, newDirNewFile1Name);
            File.WriteAllText(newDirNewFile1Path, "i have no idea what i'm doing");

            string newDirNewFile2Name = "test2.txt";
            string newDirNewFile2Path = Path.Combine(newDirPath, newDirNewFile2Name);
            File.WriteAllText(newDirNewFile2Path, "pls halp");

            string newDirNewDir1Name = "test3";
            string newDirNewDir1Path = Path.Combine(newDirPath, newDirNewDir1Name);
            Directory.CreateDirectory(newDirNewDir1Path);

            string newDirNewDir2Name = "test4";
            string newDirNewDir2Path = Path.Combine(newDirPath, newDirNewDir2Name);
            Directory.CreateDirectory(newDirNewDir2Path);

            string newDirNewDir2NewFile1Name = "test5.txt";
            string newDirNewDir2NewFile1Path = Path.Combine(newDirNewDir2Path, newDirNewDir2NewFile1Name);
            File.WriteAllText(newDirNewDir2NewFile1Path, "i crie evertim");

            string newFileName = "testRoot.txt";
            string newFilePath = Path.Combine(tempDir, newFileName);
            File.WriteAllText(newFilePath, "only got twenty dollars in my pocket");

            using (var stream = new FileStream(newZipPath, FileMode.Create))
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFolder(newDirPath, newDirName);
                zip.CreateEntryFromFolder(newDirPath, newDirName2);
                zip.CreateEntryFromFolder(newDirPath, newDir2Name);
                zip.CreateEntryFromFile(newFilePath, newFileName);
            }

            using (var stream = new FileStream(newZipPath, FileMode.Open))
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                Assert.NotNull(zip.GetEntry(newDirName + "/"));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewFile1Name));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewFile2Name));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewDir1Name + "/"));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewDir2Name + "/"));
                Assert.NotNull(zip.GetEntry(newDirName + "/" + newDirNewDir2Name + "/" + newDirNewDir2NewFile1Name));
                Assert.NotNull(zip.GetEntry(newDirName2 + "/"));
                Assert.NotNull(zip.GetEntry(newDirName2 + "/" + newDirNewFile1Name));
                Assert.NotNull(zip.GetEntry(newDirName2 + "/" + newDirNewFile2Name));
                Assert.NotNull(zip.GetEntry(newDirName2 + "/" + newDirNewDir1Name + "/"));
                Assert.NotNull(zip.GetEntry(newDirName2 + "/" + newDirNewDir2Name + "/"));
                Assert.NotNull(zip.GetEntry(newDirName2 + "/" + newDirNewDir2Name + "/" + newDirNewDir2NewFile1Name));
                Assert.NotNull(zip.GetEntry(newDir2Name + "/"));
                Assert.NotNull(zip.GetEntry(newFileName));
            }
        }

        private string GetTempDir()
        {
            string path;
            while (true)
            {
                path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                if (Directory.Exists(path))
                    continue;
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch
                {
                    continue;
                }
                return path;
            }
        }
    }
}
