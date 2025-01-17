﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Bindings;

namespace MirageMUD_Server
{
    internal class Database
    {
        // Checks if a file exists at the given path
        public bool FileExist(string file_path)
        {
            return File.Exists(file_path);
        }

        // Checks if an account exists for the given username
        public bool AccountExist(string username)
        {
            string filename = $"Accounts/{username}.json";
            return File.Exists(filename);
        }

        // Verifies if the provided password is correct for the specified account
        public bool PasswordOK(int index, string username, string password)
        {
            string filename = $"Accounts/{username}.json";
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                Types.Player[index] = JsonSerializer.Deserialize<Types.AccountStruct>(json);
            }
            else
            {
                throw new FileNotFoundException("Account file not found.");
            }

            // Return true if passwords match, otherwise false
            if (Types.Player[index].Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Adds a new account with the provided username, hashed password, and salt
        public void AddAccount(int index, string name, string hashedPassword, string salt)
        {
            ClearPlayer(index);
            Types.Player[index].Login = name;
            Types.Player[index].Password = hashedPassword; // Store the hashed password
            Types.Player[index].Salt = salt; // Store the salt

            // Clear character data for all characters
            for (int i = 0; i < Constants.MAX_CHARS; i++)
            {
                ClearChar(index, i);
            }

            SavePlayer(index);
        }

        // Clears the player login and password
        public void ClearPlayer(int index)
        {
            Types.Player[index].Login = "";
            Types.Player[index].Password = "";
        }

        // Clears the character data for a specified character
        public void ClearChar(int index, int charnum)
        {
            Types.Player[index].Character[charnum].Name = string.Empty;
            Types.Player[index].Character[charnum].Class = 1;
        }

        // Saves the player data to a JSON file
        public void SavePlayer(int index)
        {
            // Ensure the directory exists
            Directory.CreateDirectory("Accounts");

            // Construct the file path
            string filename = $"Accounts/{Types.Player[index].Login}.json";

            // Serialise the AccountStruct to JSON
            string json = JsonSerializer.Serialize(Types.Player[index], new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON data to the file
            File.WriteAllText(filename, json);
        }

        // Loads the player data from a JSON file
        public void LoadPlayer(int index, string name)
        {
            string filename = $"Accounts/{name}.json";
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                Types.Player[index] = JsonSerializer.Deserialize<Types.AccountStruct>(json);
            }
            else
            {
                throw new FileNotFoundException("Account file not found.");
            }
        }

        // Retrieves the hashed password for the specified user
        public string GetHashedPassword(string username)
        {
            string jsonFilePath = Path.Combine("Accounts", $"{username}.json"); // Assumes Accounts folder contains the user JSON files

            if (!File.Exists(jsonFilePath))
            {
                // If the file does not exist, return null
                return null;
            }

            // Read the JSON file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Parse the JSON content
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                JsonElement root = doc.RootElement;

                // Return the password field (which should be the hashed password)
                if (root.TryGetProperty("Password", out JsonElement passwordElement))
                {
                    return passwordElement.GetString();
                }
            }

            // If the password is not found, return null
            return null;
        }

        // Retrieves the salt for the specified user
        public string GetSalt(string username)
        {
            string jsonFilePath = Path.Combine("Accounts", $"{username}.json"); // Assumes Accounts folder contains the user JSON files

            if (!File.Exists(jsonFilePath))
            {
                // If the file does not exist, return null
                return null;
            }

            // Read the JSON file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Parse the JSON content
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                JsonElement root = doc.RootElement;

                // Return the salt field (if it exists)
                if (root.TryGetProperty("Salt", out JsonElement saltElement))
                {
                    return saltElement.GetString();
                }
            }

            // If the salt is not found, return null
            return null;
        }
    }
}