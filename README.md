# MiniUI

MiniUI is a small UI library that simplifies building UIs in Unity. It provides essential tools and structures for creating and managing user interfaces, including a reference-less routing solution to navigate between different pages within a Unity application.

## Features

- **UI Library**: Simplifies the creation and management of UIs in Unity.
- **No XML**: You can create all your UI elements and pages with just a single language (C#)
- **Page Previews**: You can view what your page looks like without having to play the application.
- **Page Routing**: Allows easy navigation between different UI pages.
- **In-built Tailwind**: Provides utility CSS classes to speed up UI development. (In Progress)

## Getting Started
### Installation

1. Download the package from the releases page
2. Import it into your unity project

## Usage

- **Creating a Page**: In your project explorer, Right-click > Create > MiniUI > MiniPage.
- **Adding The Page To Your Scene**:
  - In your hierarchy, Right-click > UI Toolkit > UI Document. Attach your newly created page to this Game Object to add your UI to this scene.
- **Adding a UI element to your page**: Within the RenderPage method use the provided methods to add UI elements to your page.
  - ```csharp
    //To create a UI element
    var myBtn = CreateAndAddElement<Button>();
    ```
  - ```csharp
    //To create a div
    var myDiv = CreateAndAddElement<MiniElement>();
    ```
  - ```csharp
    //To add elements to your div
    var myLabel = myDiv.CreateAndAddElement<Label>();
    ```
- **Adding styles to your Page/UI Elemets**:
  - Add a stylesheet property to your page, and then register it within your Render method
  - ```csharp
    public class NewMiniPage : MiniPage {
      [SerializeField] private StyleSheet styles;

      protected override void RenderPage() {
        AddStyleSheet(styles);
      }
    }
    ```
  - Now you can use any styles defined in your stylesheet (or the one provided with the library)
  - ```csharp
    //Adding styles when creating an element
    var myBtn = CreateAndAddElement<Button>("btn", "btn-primary", "text-bold");
    ```
  - ```csharp
    //Adding styles after an element has been created
    myBtn.AddToClassList("btn");
    ```
  - ```csharp
    //Removing styles after an element has been created
    myBtn.RemoveFromClassList("btn");
    ```
## About

MiniUI is designed to help Unity developers build user interfaces quickly and efficiently, with a focus on simplicity and ease of use.

## License

This project is licensed under the Apache-2.0 License. See the [LICENSE](LICENSE) file for details.
