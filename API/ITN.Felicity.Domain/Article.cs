﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITN.Felicity.Domain
{
    public class Article
    {
        public Article(Guid id, string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            this.Id = id;
            this.Url = url;
        }

        public Guid Id { get; private set; }
        
        public string Url { get; private set; }

        public DateTime LastUpdated { get; private set; }

        public ICollection<Feedback> Feedback { get; private set; } = new List<Feedback>();

        public void UpdateLastUpdated(DateTime lastUpdated)
        {
            if (lastUpdated > this.LastUpdated)
            {
                this.LastUpdated = lastUpdated;
            }
        }

        public void AddFeedback(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            this.Feedback.Add(feedback);
        }

        public static class Mapping
        {
            public static Expression<Func<Article, ICollection<Feedback>>> Feedback { get; } = a => a.Feedback;
        }
    }
}
