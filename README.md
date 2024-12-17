# cs-banks
C# virtual methods 


Problem Introduction

Imagine that both Deposit and Withdraw methods are called concurrently on the same account, 
and the balance is updated by multiple threads (due to async calls). This can obviously result 
in a race condition, where multiple operations affect the balance at the same time without 
being aware of each other's changes.

In C#, the graphical user interface (GUI) is typically coded using one of the following frameworks:

    Windows Forms (WinForms): This is the older, but still widely used framework for creating 
desktop applications in C#. It provides a simple event-driven programming model with built-in 
controls like buttons, labels, textboxes, and more.

    Windows Presentation Foundation (WPF): This is a more modern approach to GUI development, 
offering advanced features such as data binding, templating, and a more flexible rendering engine. 
WPF is built on the .NET framework and uses XAML (Extensible Application Markup Language) for 
defining UI components and layout.

    Universal Windows Platform (UWP): A platform for building apps that can run on all Windows 
10 devices (desktop, tablet, Xbox, etc.), UWP uses XAML for the UI and has APIs for touch, voice, 
and other modern interaction models.

    MAUI (Multi-platform App UI): A more recent framework for building cross-platform apps 
targeting Android, iOS, macOS, and Windows. MAUI allows you to write code once and deploy 
it to multiple platforms.


 ** Can you list all 11 HTTP methods, with purpose ? ** 
Here is a list of all HTTP methods, also known as HTTP verbs, which define the type of action to
be performed on the server:

    GET
       
    POST

    PUT

    DELETE

    PATCH

        OPTIONS
        
        HEAD
        
        TRACE
        
        CONNECT
        
        LINK
        
        UNLINK
