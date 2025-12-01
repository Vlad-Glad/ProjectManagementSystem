using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystem.Models
{
    [Keyless]
    public class TaskTimelineRow
    {
        public string EventType { get; set; } = null!;
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string? Text { get; set; }
        public int? Minutes { get; set; }
        public int? OldStatusId { get; set; }
        public int? NewStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
