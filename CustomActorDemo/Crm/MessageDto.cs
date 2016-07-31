using CustomActorDemo.FormHelpers;

namespace CustomActorDemo.Crm
{
    public class MessageDto
    {
        [FriendlyName("First name")]
        public string FirstName { get; set; }

        [FriendlyName("Last name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}