# EGS-CSharp-Example
C# "Hello, EGS!" as simply as possible. using Epic Game Services (part of Epic Online Services)

I did the official Epic "hello world" last night and supremely dislike the large WPF+xaml just to show minimal usage of the actual EOS network code.

Here, I take the important parts of the EOS workflow  (EGS specifically)  and ported it to a basic c# console app.   Eventually I want to add a godot example too.

This is loosely based on the official Epic WPF example blog series, found here: https://dev.epicgames.com/en-US/news/introduction-to-epic-online-services-eos

## WIP
- this is a work in progress.   
- current code does full login/logout workflows.  
- for p2p you can see `scratch/EpicP2P.cs` which I haven't incorporated into the example yet.  (If you get it working, consider contributing to this repo!)

I think I'm actually done with networking for now... I did enough research to know that I should write a server and send data through a `Span<byte>` straw to my client, so I'll just build that into my prototyping workflow for now.  I'll revisit this project for real networking once I have some playable techdemo.

# links:

- epic online services help: https://eoshelp.epicgames.com/s/?language=en_US
- epic support website: https://dev.epicgames.com/docs/support
- eos documentation: https://dev.epicgames.com/docs/epic-online-services
- EOS sdk:  only sdk files needed for this project are checked in.  login and download the full sdk here: https://dev.epicgames.com/portal
- project keys:  follow the blog series intro posts on how to login to dev portal to create your own project keys: https://dev.epicgames.com/en-US/news/introduction-to-epic-online-services-eos
- **checkout SlejmUr's EOS_GODOT repo for integration:**  https://github.com/SlejmUr/EOS_GODOT

- other maybe interesting links (maybe not)
  - [Unity Dev for Epic Games] - Part 2: Epic Online Services (EOS) C# SDK for Login and User Info https://www.youtube.com/watch?v=i2AAB60K43Q
  - Mirror: oss networking for Unity, includes examples: https://github.com/MirrorNetworking/Mirror
    - use EOS with Mirror https://github.com/FakeByte/EpicOnlineTransport
  - EOS plugin for unity : https://github.com/PlayEveryWare/eos_plugin_for_unity
  - 