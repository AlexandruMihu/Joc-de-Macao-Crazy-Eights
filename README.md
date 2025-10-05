# Macao (Crazy Eights)

**Macao** is a Windows Forms C# implementation of the popular card game **Crazy Eights** (locally known as *Macao*). The project supports two-player LAN matches (server / client), implements full game rules (special cards, stacking mechanics, turn-based play) and synchronizes game state over a lightweight TCP message protocol.

---

## Key features

* Two-player LAN play (server & client) using `TcpListener` / `NetworkStream`.
* Full Macao/Crazy Eights rules: draw/play actions, stacking, stop cards (K), aces (skip), 7s (change suit), jokers and custom penalties.
* Turn-based gameplay with UI controls enabled/disabled according to the active player.
* Automatic deck creation, shuffle, draw pile refill from discard and synchronization across networked clients.
* Clickable card visuals — PictureBox controls are generated at runtime from resource images; only the current player's cards are selectable.
* Simple, human-readable message protocol for synchronization (compact numeric codes with `*` / `%` delimiters).

---

## Technical stack

* **Language:** C#
* **UI:** Windows Forms (WinForms)
* **IDE:** Visual Studio 2022
* **Networking:** TCP sockets (`TcpListener`, `Socket`, `NetworkStream`, `StreamReader`/`StreamWriter`)
* **Tools used for documentation/diagrams:** Word, Visual Paradigm, diagrams.net

---

## How to run

1. Open `JocMacao.sln` in Visual Studio 2022. The solution contains two projects: the **Server** build and the **Client** build.
2. Build both projects.
3. Start one instance as **Server** and the other as **Client** (both must be on the same LAN):

   * Server: `Start` → enter name → wait for client to connect.
   * Client: `Start` → enter name → enter server IP in the Connect field → press `Connect`.
4. After connection each player receives 5 cards and the game begins. Use the **"Ia carte" (Draw)** and **"Pune carte" (Play)** buttons to interact.

---

## Controls & UI

* **Draw a card:** Click **Ia carte** when it is your turn.
* **Play a card:** Click a selectable card to mark it, then **Pune carte** to play it (button enabled only when the selected card is compatible).
* Important UI elements: `labelTurnPlayer`, `labelCarteCurenta`, `labelPachetOriginal`, `labelPachetDeJos`, `btnIaCarte`, `btnPuneCarte`, `btnConnect`, and `textBoxIP`.

---

## Networking protocol (summary)

Messages are encoded as short numeric codes with `*` separators. Examples used in the project:

* `#*name` — exchange player names.
* `0*cardName` — add card to original deck.
* `1*cardName` / `2*cardName` — give card to Player1 / Player2.
* `3*cardName` — update discard/top card.
* `4*cardName*mode*stack*turn` — play a card (includes mode/stack/turn state).
* `5*mode*stack*turn` — synchronize a draw action.
* `6*listOfCards*n` — refill original deck with serialized discard list.
* `7*` — clear both decks (reset).

This compact protocol keeps both endpoints synchronized with minimal overhead and is straightforward to extend.

---

## Architecture & main classes

* **Forms:** `fStart`, `fInstrunctiuni`, `fNume`, `fJoc` — UI flow for menu, instructions, name entry and gameplay.
* **Core classes:** `Carte` (card model), `Pachet` (deck), `Player` (player hand and actions), `JocMacaoServer` / `JocMacaoClient` (game controller, rules enforcement and network handling).
* **Design notes:** Cards are represented by enums (`SIMBOL`, `VALOARE`) and have image resources whose filenames match card identifiers. Decks and players are displayed by creating and positioning PictureBox controls at runtime.

---

## Known limitations & future improvements

* Only two-player LAN matches (no matchmaking or internet play).
* No persistence of match history or player profiles.
* UI/UX can be polished (animations, responsive layout) and network protocol can be hardened (error handling, reconnection).

Planned improvements: add AI opponent mode, multi-player support, better error handling and logging, unit tests for core logic.

---

## Credits

Author: Alexandru Mihu (project documentation and implementation). See the included documentation for diagrams and detailed design notes.


*If you want, I can provide a Romanian translation, a shorter README, or generate a `CONTRIBUTING.md` and `CHANGELOG.md` based on the version history in the documentation.*
