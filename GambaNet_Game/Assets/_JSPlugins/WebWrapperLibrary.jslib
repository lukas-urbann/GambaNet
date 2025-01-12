mergeInto(LibraryManager.library,
{
  OnGameStart: function ()
  {
    console.log("Game loaded...");
    LoadGameData();
  },
});