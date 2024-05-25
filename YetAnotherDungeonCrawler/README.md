# Yet Another Dungeon Crawler

## Authors

+ João Fernandes - 22304583
+ Inês Gomes - 22305790

<!---
Add here what each of us did
-->

## Sln Architecture

<!---
Add here the description of the sln, how it was organized and the non trivial algorithms used
-->

### Class Diagram

```mermaid
---

---
classDiagram
    Program --> Controller
    Program --> Player
    Program --> View

    Controller --> Dungeon
    Controller --> Room
    Controller --> Player

    IView <|-- View

    View --> Player

    Character <|-- Player
    Character <|-- Enemy

    Player --> Room
    Player o-- Item

    Dungeon o-- Room

    Room --> Enemy

    Item <-- Room

    <<Interface>> IView
    <<Enum>> Item
```

### Map

<!---
Add Map Here
-->

## References
