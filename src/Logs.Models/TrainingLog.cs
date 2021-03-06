﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logs.Models
{
    public class TrainingLog
    {
        public TrainingLog()
        {
            this.Votes = new HashSet<Vote>();
            this.Entries = new HashSet<LogEntry>();
        }

        public TrainingLog(string name, string description, DateTime dateCreated, User user)
            : this()
        {
            this.Name = name;
            this.Description = description;
            this.DateCreated = dateCreated;
            this.User = user;
            this.User.Log = this;
            this.Owner = user.UserName;

            this.LastEntryDate = this.DateCreated;
            this.LastActivityUser = this.User.UserName;
        }

        [Key]
        public int LogId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string LastActivityUser { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastEntryDate { get; set; }

        public virtual LogEntry LastEntry { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<LogEntry> Entries { get; set; }
    }
}
