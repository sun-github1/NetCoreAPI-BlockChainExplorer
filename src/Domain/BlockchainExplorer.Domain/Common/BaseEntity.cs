using System.ComponentModel.DataAnnotations;


namespace BlockchainExplorer.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
