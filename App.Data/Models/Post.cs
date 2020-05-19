using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Data.Models
{
    public enum PostType
    {
        Question,
        Poll
    }

    public enum PostStatus
    {
        solved,
        inProgress
    }
    public class Post
    {
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Title { get; set; }
        [Required]
        public PostType postType { get; set; }
        [Required]
        public PostStatus postStatus { get; set; }
        public int Rate { get; set; }
        [Required]
        public DateTime PublishTime { get; set; }
        public long AnswersNum { get; set; } = 0;
        public long viewNum { get; set; } = 0;
        public int UserId { get; set; }
        public UserDetails Owner { get; set; }
    }
}
