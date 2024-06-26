using FluentValidation.TestHelper;
using Shop.BLL.Common.DataTransferObjects.Categories;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.BLL.Common.Validators.Games;

namespace Shop.Test.DtoValidatorsTests
{
    public class GameValidatorsTests
    {
        private readonly GameCreationDtoValidator _creationValidator = new();
        private readonly GameUpdateDtoValidator _updateValidator = new();

        #region Creation dto validation

        [Theory]
        [MemberData(nameof(GetEmptyFieldsCreationGames))]
        public void NullFieldsGameCreation_ShouldHaveValidationError(GameRequestCreationDto game)
        {
            var result = _creationValidator.TestValidate(game);

            result.ShouldHaveAnyValidationError();
        }

        [Theory]
        [MemberData(nameof(GetInvalidFieldsCreationGames))]
        public void InvalidFieldsGameCreation_ShouldHaveValidationError(
            GameRequestCreationDto game, string fieldName)
        {
            var result = _creationValidator.TestValidate(game);

            result.ShouldHaveValidationErrorFor(fieldName);
        }

        [Theory]
        [MemberData(nameof(GetValidCreationGames))]
        public void ValidGameCreation_ShouldNotHaveValidationError(GameRequestCreationDto game)
        {
            var result = _creationValidator.TestValidate(game);

            result.ShouldNotHaveAnyValidationErrors();
        }

        #endregion

        #region Update dto validation 

        [Theory]
        [MemberData(nameof(GetEmptyFieldsUpdateGames))]
        public void NullFieldsGameUpdate_ShouldHaveValidationError(GameRequestUpdateDto game)
        {
            var result = _updateValidator.TestValidate(game);

            result.ShouldHaveAnyValidationError();
        }

        [Theory]
        [MemberData(nameof(GetInvalidFieldsUpdateGames))]
        public void InvalidFieldsGameUpdate_ShouldHaveValidationError(
            GameRequestUpdateDto game, string fieldName)
        {
            var result = _updateValidator.TestValidate(game);

            result.ShouldHaveValidationErrorFor(fieldName);
        }

        [Theory]
        [MemberData(nameof(GetValidUpdateGames))]
        public void ValidGameUpdate_ShouldNotHaveValidationError(GameRequestUpdateDto game)
        {
            var result = _updateValidator.TestValidate(game);

            result.ShouldNotHaveAnyValidationErrors();
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> GetEmptyFieldsCreationGames()
        {
            return
            [
                [new GameRequestCreationDto()],
                [new GameRequestCreationDto() { Name = "TestName" }],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription"
                    }
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper"
                    }
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher"
                    }
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m
                    }
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [2,1]
                    }
                ],
            ];
        }

        public static IEnumerable<object[]> GetInvalidFieldsCreationGames()
        {
            return
            [
                [
                    new GameRequestCreationDto()
                    {
                        Name = "1234567890123456789012345678901",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [2,1],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2"
                        ]
                    },
                    nameof(GameRequestCreationDto.Name)
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis vehicula ligula, euismod fermentum lorem. Vivamus scelerisque, arcu vel ullamcorper congue, leo metus faucibus nibh, eget vulputate enim arcu eu tellus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Donec quam ligula, consectetur in pretium eget, accumsan in dolor. Sed a magna tellus. Aliquam eu dictum augue. Suspendisse lacinia fermentum tortor, et auctor risus elementum nec. Donec in consequat metus, quis auctor sem. Fusce sodales lectus quam, ac varius lectus congue at. Nulla orci.",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [2,1],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2"
                        ]
                    },
                    nameof(GameRequestCreationDto.Description)
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "12345678901234567890123456789012345678901",
                        Price = 12m,
                        Image = [2,1],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2"
                        ]
                    },
                    nameof(GameRequestCreationDto.Publisher)
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "12345678901234567890123456789012345678901",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [2,1],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2"
                        ]
                    },
                    nameof(GameRequestCreationDto.Developer)
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 0m,
                        Image = [2,1],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2"
                        ]
                    },
                    nameof(GameRequestCreationDto.Price)
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = -10m,
                        Image = [2,1],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2"
                        ]
                    },
                    nameof(GameRequestCreationDto.Price)
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 100000m,
                        Image = [2,1],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2"
                        ]
                    },
                    nameof(GameRequestCreationDto.Price)
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [2,1],
                        Categories =
                        [
                            "1234567890123456789012345678901",
                            "Test Category 2"
                        ]
                    },
                    $"{nameof(GameRequestCreationDto.Categories)}[0]"
                ],
            ];
        }

        public static IEnumerable<object[]> GetValidCreationGames()
        {
            return
            [
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [1,2],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    }
                ],
                [
                    new GameRequestCreationDto()
                    {
                        Name = "TestName 2",
                        Description = "TestDescription 2",
                        Developer = "TestDeveloper 2",
                        Publisher = "TestPublisher 2",
                        Price = 125m,
                        Image = [1,2,1,1,2],
                        Categories =
                        [
                            "Test Category 6",
                            "Test Category 8",
                        ]
                    }
                ],
            ];
        }


        public static IEnumerable<object[]> GetEmptyFieldsUpdateGames()
        {
            return
            [
                [new GameRequestUpdateDto()],
                [new GameRequestUpdateDto() { Name = "TestName" }],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription"
                    }
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper"
                    }
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher"
                    }
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m
                    }
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [1,2]
                    }
                ],
            ];
        }

        public static IEnumerable<object[]> GetInvalidFieldsUpdateGames()
        {
            return
            [
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "1234567890123456789012345678901",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [1,2],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    },
                    nameof(GameRequestUpdateDto.Name)
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis vehicula ligula, euismod fermentum lorem. Vivamus scelerisque, arcu vel ullamcorper congue, leo metus faucibus nibh, eget vulputate enim arcu eu tellus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Donec quam ligula, consectetur in pretium eget, accumsan in dolor. Sed a magna tellus. Aliquam eu dictum augue. Suspendisse lacinia fermentum tortor, et auctor risus elementum nec. Donec in consequat metus, quis auctor sem. Fusce sodales lectus quam, ac varius lectus congue at. Nulla orci.",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [1,2],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    },
                    nameof(GameRequestUpdateDto.Description)
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "12345678901234567890123456789012345678901",
                        Price = 12m,
                        Image = [1,2],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    },
                    nameof(GameRequestUpdateDto.Publisher)
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "12345678901234567890123456789012345678901",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [1,2],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    },
                    nameof(GameRequestUpdateDto.Developer)
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 0m,
                        Image = [1,2],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    },
                    nameof(GameRequestUpdateDto.Price)
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = -10m,
                        Image = [1,2],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    },
                    nameof(GameRequestUpdateDto.Price)
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 100000m,
                        Image = [1,2],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    },
                    nameof(GameRequestUpdateDto.Price)
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [1,2],
                        Categories =
                        [
                            "1234567890123456789012345678901",
                            "Test Category 2",
                        ]
                    },
                    $"{nameof(GameRequestUpdateDto.Categories)}[0]"
                ],
            ];
        }

        public static IEnumerable<object[]> GetValidUpdateGames()
        {
            return
            [
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName",
                        Description = "TestDescription",
                        Developer = "TestDeveloper",
                        Publisher = "TestPublisher",
                        Price = 12m,
                        Image = [1,2,3],
                        Categories =
                        [
                            "Test Category 1",
                            "Test Category 2",
                        ]
                    }
                ],
                [
                    new GameRequestUpdateDto()
                    {
                        Name = "TestName 2",
                        Description = "TestDescription 2",
                        Developer = "TestDeveloper 2",
                        Publisher = "TestPublisher 2",
                        Price = 125m,
                        Image = [1,2,3,2,1],
                        Categories =
                        [
                            "Test Category 6",
                            "Test Category 8",
                        ]
                    }
                ],
            ];
        }

        #endregion

    }
}