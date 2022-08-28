# NED (Numeric Entity Doubler)
 An application (and algorithm) that can *encrypt* data via expansion and *decrypt* data via compression. 
 
## How It Works
- **Input: Z**
- **Key: 10**
- **Recursion: 2**

![Flowchart](https://user-images.githubusercontent.com/59519774/187068994-94167852-f8d2-455e-bf3c-4eaa549892f1.png)
## Using NED
In order for the NED application to operate properly, [.NET Runtime 6.0.8](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) must be downloaded.

### Precautions
- Only keys between 10 and 74 can be decrypted **without** error.
- High recursions are probably not good to use...

## Planned Updates
- Correct decryption of keys below 10
- Migration to a Desktop Application
