using System.ComponentModel.DataAnnotations;

namespace WorkSpace.ViewModels.Request
{
    public class CreateElementRequest
    {
        [Required]
        public string ContentHtml { get; set; }
        [Required]
        public int BlockId { get; set; }
    }
}
