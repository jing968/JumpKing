# Replicating Jump King and applying basica learning algorithm

## Background of the project 🤔

This is the main project for the COMP4121 Advanced Algorithm, where I have choose to replicate the Jump King game and apply a classification learning algorithm to allow the replicated game to beat itself

## Working with this repo 🛠

In order to set up the project and run it locally there are a few things that need to be set up properly.

#### **GitHub**

GitHub is the primary tool used for version-control in this project.

#### **Unity**

This Unity project is built with Unity editor version **202.3.33f1** please install that particular version of the unity editor to avoid unnecessary conflicts.

### **Other**

If you are using VScode as editor and wish to make use of the autocomplete feature, you will also need to set that up following this [guide](https://code.visualstudio.com/docs/other/unity). You may also find this [video](https://youtube.com/watch?v=CTV5IkDTGYo&t) useful.

## Game Mode 🕹

The application has three game mode, namely **Play**, **Test** and **Train**.

### Play

In the **Play** mode, player can manually play through the game manually using the controls provided in the orignal game.

| Mechanics |                                                                        Description                                                                        |     Controls |
| :-------- | :-------------------------------------------------------------------------------------------------------------------------------------------------------: | -----------: |
| Movmment  |                                                       left or right arrow keys to control movements                                                       | `<-` OR `->` |
| Jump      | space bar to jump, hold down the space bar for a more powerful jump, combine space bar with any left or right arrow key to perform a jump with direction. |  `Space Bar` |
| Menu      |                                                             use the esc key trigger the menu                                                              |        `Esc` |

### Test

In the **Test** mode, players can withness the learner performing all the "good jump" it previously learnt from **train** mode

### Train

In the **Train** phase, players can withness the learner trying to learn the game

## Leftover objectives 📌

Game Replication

- [ ] Replicate the exact game map from the original game
- [ ] Replicate the entire game map
- [ ] Replicate the exact jump mechanics from the original game
- [ ] Replicate UI & UX from the original game

Learning Algorithm

- [ ] Add support for mulitple learners
- [ ] Imrpove the learning algorithm
- [ ] Filter useless "good jumps"

## Author

Jing Sheng Deng (z5213505)
