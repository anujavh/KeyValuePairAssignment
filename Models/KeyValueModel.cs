using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyValuePairAssignment.Models
{

    [Table("KeyValueTable")]
    [PrimaryKey("Key")]
    public class KeyValueModel
    {
        public int Key { get; set; }
        public required string Value { get; set; }

    }
}
