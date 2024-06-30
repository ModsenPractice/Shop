using FluentValidation.TestHelper;
using Shop.BLL.Common.DataTransferObjects.Users;
using Shop.BLL.Common.Validators.Users;

namespace Shop.Test.DtoValidatorsTests
{
    public class UserValidatorsTests
    {
        private readonly UserRegistrationDtoValidator _registrationValidator = new();
        private readonly UserUpdateDtoValidator _updateValidator = new();
        private readonly UserAuthorizationDtoValidator _authValidator = new();

        #region Registration dto validation

        [Theory]
        [MemberData(nameof(GetValidRegistrationUsers))]
        public void ValidRegistrationUser_ShouldNotHaveValidationError(
            UserRequestRegistrationDto user)
        {
            var result = _registrationValidator.TestValidate(user);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [MemberData(nameof(GetInvalidRegistrationUsers))]
        public void InvalidRegistrationUser_ShouldHaveValidationError(
            UserRequestRegistrationDto user, string errorField)
        {
            var result = _registrationValidator.TestValidate(user);

            result.ShouldHaveValidationErrorFor(errorField);
        }

        #endregion

        #region Update dto validation

        [Theory]
        [MemberData(nameof(GetValidUpdateUsers))]
        public void ValidUpdateUser_ShouldNotHaveValidationError(
            UserRequestUpdateDto user)
        {
            var result = _updateValidator.TestValidate(user);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [MemberData(nameof(GetInvalidUpdateUsers))]
        public void InvalidUpdateUser_ShouldHaveValidationError(
            UserRequestUpdateDto user, string errorField)
        {
            var result = _updateValidator.TestValidate(user);

            result.ShouldHaveValidationErrorFor(errorField);
        }

        #endregion

        #region  Authorization dto validation

        [Theory]
        [MemberData(nameof(GetValidAuthUsers))]
        public void ValidAuthUser_ShouldNotHaveValidationError(
            UserRequestAuthorizationDto user)
        {
            var result = _authValidator.TestValidate(user);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [MemberData(nameof(GetInvalidAuthUsers))]
        public void InvalidAuthUser_ShouldHaveValidationError(
            UserRequestAuthorizationDto user, string errorField)
        {
            var result = _authValidator.TestValidate(user);

            result.ShouldHaveValidationErrorFor(errorField);
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> GetValidRegistrationUsers()
        {
            return
            [
                [
                    new UserRequestRegistrationDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser@gmail.com",
                        Password = "qwertyui12345689",
                        FirstName = "Kirill",
                        LastName = "Meleshko",
                        BirthDay = DateOnly.Parse("01-25-2004"),
                        Roles = ["admin"]
                    }
                ],
                [
                    new UserRequestRegistrationDto()
                    {
                        UserName = "TestUser2",
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Marat",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-2002"),
                        Roles = ["customer"]
                    }
                ]
            ];
        }

        public static IEnumerable<object[]> GetInvalidRegistrationUsers()
        {
            return
            [
                [
                    new UserRequestRegistrationDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser",
                        Password = "qwertyui12345689",
                        FirstName = "Kirill",
                        LastName = "Meleshko",
                        BirthDay = DateOnly.Parse("01-25-2004"),
                        Roles = ["admin"]
                    },
                    nameof(UserRequestRegistrationDto.Email)
                ],
                [
                    new UserRequestRegistrationDto()
                    {
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Marat",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-2002"),
                        Roles = ["customer"]
                    },
                    nameof(UserRequestRegistrationDto.UserName)
                ],
                [
                    new UserRequestRegistrationDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Marat",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-1800"),
                        Roles = ["customer"]
                    },
                    nameof(UserRequestRegistrationDto.BirthDay)
                ],
                [
                    new UserRequestRegistrationDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Mar12at",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-2002"),
                        Roles = ["customer"]
                    },
                    nameof(UserRequestRegistrationDto.FirstName)
                ],
                [
                    new UserRequestRegistrationDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Marat",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-2002"),
                        Roles = []
                    },
                    nameof(UserRequestRegistrationDto.Roles)
                ]
            ];
        }

        public static IEnumerable<object[]> GetValidUpdateUsers()
        {
            return
            [
                [
                    new UserRequestUpdateDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser@gmail.com",
                        Password = "qwertyui12345689",
                        FirstName = "Kirill",
                        LastName = "Meleshko",
                        BirthDay = DateOnly.Parse("01-25-2004"),
                        Roles = ["admin"]
                    }
                ],
                [
                    new UserRequestUpdateDto()
                    {
                        UserName = "TestUser2",
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Marat",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-2002"),
                        Roles = ["customer"]
                    }
                ]
            ];
        }

        public static IEnumerable<object[]> GetInvalidUpdateUsers()
        {
            return
            [
                [
                    new UserRequestUpdateDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser",
                        Password = "qwertyui12345689",
                        FirstName = "Kirill",
                        LastName = "Meleshko",
                        BirthDay = DateOnly.Parse("01-25-2004"),
                        Roles = ["admin"]
                    },
                    nameof(UserRequestUpdateDto.Email)
                ],
                [
                    new UserRequestUpdateDto()
                    {
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Marat",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-2002"),
                        Roles = ["customer"]
                    },
                    nameof(UserRequestUpdateDto.UserName)
                ],
                [
                    new UserRequestUpdateDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Marat",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-1800"),
                        Roles = ["customer"]
                    },
                    nameof(UserRequestUpdateDto.BirthDay)
                ],
                [
                    new UserRequestUpdateDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Mar12at",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-2002"),
                        Roles = ["customer"]
                    },
                    nameof(UserRequestUpdateDto.FirstName)
                ],
                [
                    new UserRequestUpdateDto()
                    {
                        UserName = "TestUser",
                        Email = "testuser2@gmail.com",
                        Password = "qwerty123456",
                        FirstName = "Marat",
                        LastName = "Sharifulin",
                        BirthDay = DateOnly.Parse("03-16-2002"),
                        Roles = []
                    },
                    nameof(UserRequestUpdateDto.Roles)
                ]
            ];
        }

        public static IEnumerable<object[]> GetValidAuthUsers()
        {
            return
            [
                [
                    new UserRequestAuthorizationDto()
                    {
                        Username = "testUsernametestUsernametestUs",
                        Password = "qwertyui123456789"
                    }
                ],
                [
                    new UserRequestAuthorizationDto()
                    {
                        Username = "testUsername",
                        Password = "qwertyui1234567812319"
                    }
                ],
                [
                    new UserRequestAuthorizationDto()
                    {
                        Username = "name",
                        Password = "qwertyui1234567812319"
                    }
                ]
            ];
        }

        public static IEnumerable<object[]> GetInvalidAuthUsers()
        {
            return
            [
                [
                    new UserRequestAuthorizationDto()
                    {
                        Password = "qwertyui123456789"
                    },
                    nameof(UserRequestAuthorizationDto.Username)
                ],
                [
                    new UserRequestAuthorizationDto()
                    {
                        Username = "test2mail@gmail.com"
                    },
                    nameof(UserRequestAuthorizationDto.Password)
                ],
                [
                    new UserRequestAuthorizationDto()
                    {
                        Username = "test2mail@gmail.com",
                        Password = "1234"
                    },
                    nameof(UserRequestAuthorizationDto.Password)
                ],
                [
                    new UserRequestAuthorizationDto()
                    {
                        Username = "tes",
                        Password = "123412312312"
                    },
                    nameof(UserRequestAuthorizationDto.Username)
                ]
            ];
        }

        #endregion
    }
}