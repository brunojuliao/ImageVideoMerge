# Image Video Merge
This project was born as a POC. A friend asked if it was posible to recreate what Facebook does, like you have a video and photos merged to create something unique and personal.

This is the repository to what will be the core engine. A helper anyone will be able to use in whatever interface they are using (command, web, forms).

.net core 2.0 was used in this lib, to make it portable (run on Linux or Windows).

As a requirement, you need to have ffmpeg instealled. Its path needs to informed via config (key ffmpegPath) or through constructor.