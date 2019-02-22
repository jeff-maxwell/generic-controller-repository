using System;
using System.ComponentModel.DataAnnotations;

namespace GenericControllerRepository.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
        }
        public BaseModel(BaseModel m)
        {
            this.Id = m.Id;
            this.Name = m.Name;

            this.Deleted = m.Deleted;
            
            this.CreatedDate = m.CreatedDate;
            this.UpdatedDate = m.UpdatedDate;
            this.DeletedDate = m.DeletedDate;
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}