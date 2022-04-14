using Blogfa.Domain.UserAgg.Enums;
using Blogfa.Domain.UserAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Blogfa.Domain.UserAgg
{
    public class User : AggregateRoot
	{
        public string FirstName { get;private set; }
        public string LastName { get; private set; }
        public string Avatar { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsActive { get; private set; }
        public Gender Gender { get; private set; }

        public List<UserRole> Roles { get; set; }

        private User() { }

        public User(string firstName, string lastName, string avatar, string password, string phoneNumber,
            bool isActive, Gender gender,List<UserRole> userRoles,IUserDomainService userService)
        {
            Guard(firstName, lastName, password, phoneNumber, userService);

            FirstName = firstName;
            LastName = lastName;
            Avatar = avatar;
            Password = password;
            PhoneNumber = phoneNumber;
            IsActive = isActive;
            Gender = gender;
            AddRoles(userRoles);
        }

        public static User Register(string firstName, string lastName, string password, string phoneNumber, IUserDomainService userService) =>
            new(firstName, lastName, "NoImage.jpeg", password, phoneNumber, false,Gender.Male,null!, userService);

        public void Edit(string firstName, string lastName, string avatar, Gender gender,List<UserRole> userRoles)
        {
            FirstName = firstName;
            LastName = lastName;
            Avatar = avatar;
            Gender = gender;
            EditRoles(userRoles);
        }

        public void Active() => IsActive = true;
        public void DeActive() => IsActive = false;

        public void ChangePassword(string password)
        {
            if (!string.IsNullOrWhiteSpace(password))
                Password = password;
        }

        public void AddRoles(List<UserRole> roles)
        {
            if (roles is null) return;
            roles.ForEach(r => r.UserId = Id);
            Roles.AddRange(roles);
        }

        public void EditRoles(List<UserRole> roles)
        {
            Roles?.Clear();
            AddRoles(roles);
        }

        private void Guard(string firstName, string lastName, string password, string phoneNumber,IUserDomainService userService)
        {
            NullOrEmptyDomainDataException.CheckString(firstName, nameof(firstName));
            NullOrEmptyDomainDataException.CheckString(lastName, nameof(lastName));
            NullOrEmptyDomainDataException.CheckString(password, nameof(password));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if (userService.IsPhoneNumberExist(phoneNumber))
                throw new InvalidDomainDataException("This Phone Number Is Already Exist");
        }
    }
}