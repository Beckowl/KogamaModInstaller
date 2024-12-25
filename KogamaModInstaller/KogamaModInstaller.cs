using System.IO.Compression;
using KogamaModInstaller.Properties;

namespace KogamaModInstaller;
public partial class KogamaModInstaller : Form
{
    private string modPath = string.Empty;
    private string installPath = string.Empty;

    public KogamaModInstaller()
    {
        InitializeComponent();
    }

    private void tb_modPath_TextChanged(object sender, EventArgs e)
    {
        string path = tb_modPath.Text;
        bool extensionValid = Path.GetExtension(path).Equals(".dll", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(path).Equals(".zip", StringComparison.OrdinalIgnoreCase);

        lbl_modInvalid.Visible = !extensionValid;

        if (extensionValid)
        {
            modPath = path;
        }

        UpdateButtonStates();
    }

    private void btn_browseMod_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "(*.zip;*.dll)|*.zip;*.dll|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_modPath.Text = openFileDialog.FileName;
            }
        }
    }

    private void rb_serverBR_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_serverBR.Checked)
        {
            installPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KogamaLauncher-BR\\Launcher\\Standalone");
        }
        UpdateButtonStates();
    }

    private void rb_serverFriends_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_serverFriends.Checked)
        {
            installPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KogamaLauncher-Friends\\Launcher\\Standalone");
        }
        UpdateButtonStates();
    }

    private void rb_serverWWW_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_serverWWW.Checked)
        {
            installPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KogamaLauncher-WWW\\Launcher\\Standalone");
        }
        UpdateButtonStates();
    }

    private void rb_serverCustom_CheckedChanged(object sender, EventArgs e)
    {
        tb_customInstallPath.Enabled = rb_serverCustom.Checked;
        btn_browseInstallPath.Enabled = rb_serverCustom.Checked;

        installPath = tb_customInstallPath.Text;
        UpdateButtonStates();
    }

    private void tb_customInstallPath_TextChanged(object sender, EventArgs e)
    {
        bool validFolder = IsValidGameFolder(tb_customInstallPath.Text);

        if (validFolder)
        {
            installPath = tb_customInstallPath.Text;
        }

        lbl_installInvalid.Visible = !validFolder;

        UpdateButtonStates();
    }

    private void btn_browseInstallPath_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Select your game's \"Standalone\" folder.";
            folderBrowserDialog.UseDescriptionForTitle = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tb_customInstallPath.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }

    private async void btn_install_Click(object sender, EventArgs e)
    {
        Progress<int> progress = new Progress<int>(new Action<int>(UpdateProgressBar));
        btn_install.Enabled = false;
        btn_install.Enabled = false;


        await Task.Run(delegate
        {
            Install(progress);
        });

        btn_install.Enabled = true;
        btn_install.Enabled = true;

    }

    private async void btn_uninstall_Click(object sender, EventArgs e)
    {
        Progress<int> progress = new Progress<int>(new Action<int>(UpdateProgressBar));

        btn_uninstall.Enabled = false;
        btn_install.Enabled = false;

        await Task.Run(delegate
        {
            Uninstall(progress);
        });

        btn_uninstall.Enabled = true;
        btn_install.Enabled = true;
    }

    private bool IsValidGameFolder(string path)
    {
        return File.Exists(Path.Combine(path, "Kogama.exe"));
    }

    private void UpdateButtonStates()
    {
        btn_uninstall.Enabled = !string.IsNullOrEmpty(installPath) && !string.IsNullOrEmpty(modPath);
        btn_install.Enabled = !string.IsNullOrEmpty(installPath) && !string.IsNullOrEmpty(modPath);
    }

    private void UpdateProgressBar(int value)
    {
        if (InvokeRequired)
        {
            Invoke(delegate
            {
                progressBar.Value = value;
            });
            return;
        }
        progressBar.Value = value;
    }

    private void Install(IProgress<int> progress)
    {
        try
        {
            progress?.Report(0);

            using (MemoryStream memoryStream = new MemoryStream(Resources.be_692_851521c))
            using (ZipArchive zipArchive = new ZipArchive(memoryStream))
            {
                int totalEntries = zipArchive.Entries.Count;
                int currentEntry = 0;

                foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                {
                    string destinationPath = Path.Combine(installPath, zipArchiveEntry.FullName);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);

                    if (!string.IsNullOrEmpty(zipArchiveEntry.Name))
                    {
                        zipArchiveEntry.ExtractToFile(destinationPath, overwrite: true);
                    }

                    currentEntry++;
                    progress?.Report(currentEntry * 50 / totalEntries);
                }
            }

            string pluginsPath = Path.Combine(installPath, "BepInEx", "Plugins");
            Directory.CreateDirectory(pluginsPath);

            string fileExtension = Path.GetExtension(modPath).ToLower();

            if (fileExtension == ".zip")
            {
                using (FileStream fileStream = new FileStream(modPath, FileMode.Open))
                using (ZipArchive zipArchive = new ZipArchive(fileStream))
                {
                    int totalEntries = zipArchive.Entries.Count;
                    int currentEntry = 0;

                    foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                    {
                        string destinationPath = Path.Combine(pluginsPath, zipArchiveEntry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);

                        if (!string.IsNullOrEmpty(zipArchiveEntry.Name))
                        {
                            zipArchiveEntry.ExtractToFile(destinationPath, overwrite: true);
                        }

                        currentEntry++;
                        progress?.Report(50 + currentEntry * 50 / totalEntries);
                    }
                }
            }
            else if (fileExtension == ".dll")
            {
                string destinationPath = Path.Combine(pluginsPath, Path.GetFileName(modPath));
                File.Copy(modPath, destinationPath, overwrite: true);
                progress?.Report(100);
            }

            MessageBox.Show("Installation successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Installation failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            progress?.Report(0);
        }
    }

    private void Uninstall(IProgress<int> progress)
    {
        try
        {
            string pluginsPath = Path.Combine(installPath, "BepInEx", "Plugins");
            string fileExtension = Path.GetExtension(modPath).ToLower();

            if (fileExtension == ".dll")
            {
                string modFilePath = Path.Combine(pluginsPath, Path.GetFileName(modPath));
                if (File.Exists(modFilePath))
                {
                    File.Delete(modFilePath);
                    progress?.Report(100);
                }
            }
            else if (fileExtension == ".zip")
            {
                using (FileStream fileStream = new FileStream(modPath, FileMode.Open))
                using (ZipArchive zipArchive = new ZipArchive(fileStream))
                {
                    int totalEntries = zipArchive.Entries.Count;
                    int currentEntry = 0;

                    foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                    {
                        string destinationPath = Path.Combine(pluginsPath, zipArchiveEntry.FullName);
                        if (File.Exists(destinationPath))
                        {
                            File.Delete(destinationPath);
                        }

                        currentEntry++;
                        progress?.Report((currentEntry / totalEntries) * 100);
                    }
                }
            }

            MessageBox.Show("Uninstalled completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Uninstallation failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            progress?.Report(0);
            btn_uninstall.Enabled = true;
        }
    }

}
