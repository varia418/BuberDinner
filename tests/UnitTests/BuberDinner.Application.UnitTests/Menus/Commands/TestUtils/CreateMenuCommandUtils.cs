using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateCommand(
        List<CreateMenuSectionCommand>? sections = null
    ) =>
        new CreateMenuCommand(
            Constants.Host.Id.ToString()!,
            Constants.Menu.Name,
            Constants.Menu.Description,
            sections ?? CreateMenuSectionsCommand()
        );

    public static List<CreateMenuSectionCommand> CreateMenuSectionsCommand(
        int sectionCount = 1,
        List<CreateMenuItemCommand>? items = null
    ) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index),
                items ?? CreateMenuItemsCommand()
            )).ToList();

    public static List<CreateMenuItemCommand> CreateMenuItemsCommand(int itemCount = 1) =>
        Enumerable.Range(0, itemCount)
            .Select(index => new CreateMenuItemCommand(
                Constants.Menu.ItemNameFromIndex(index),
                Constants.Menu.ItemDescriptionFromIndex(index)
            )).ToList();
}