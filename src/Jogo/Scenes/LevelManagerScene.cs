
using Raylib_cs;

/// <summary>
/// Handles levels, responsible for making the transition between the LevelScenes.
/// </summary>
public class LevelManagerScene : IScene
{
    private const string LevelListPath = @"Levels/custom-levels.yaml";
    private LevelScene currentLevel;
    private int levelIndex;
    private readonly int levelCount = LevelLoader.GetLevelCount(LevelListPath);
    private HUD _hud;

    /// <summary>
    /// Generates a new LevelManagerScene.
    /// </summary>
    /// <param name="index">Index of the first level to be shown.</param>
    public LevelManagerScene(uint index) {
        levelIndex = (int) index;
        currentLevel = new LevelScene([new TickUpdateSystem(), new CollisionSystem(), new ItemCollectionSystem()], LevelLoader.LoadFromYaml(LevelListPath, levelIndex));
        _hud = new HUD();
        _hud.MenuButton.ButtonPressed += OnMenuButtonPressed;
        _hud.RestartButton.ButtonPressed += OnRestartButtonPressed;
    }

    private void OnRestartButtonPressed(object? sender, EventArgs e)
    {
        SetLevel((uint) levelIndex);
    }

    private void OnMenuButtonPressed(object? sender, EventArgs e)
    {
        GameSystem.currentScene = new MainMenuScene();
    }

    public void Render()
    {
        currentLevel.Render();
        _hud.Render();
    }

    public void Update()
    {
        if(currentLevel.Player.PlayerKilled || Raylib.IsKeyPressed(KeyboardKey.R)) {
            SetLevel((uint) levelIndex);
        }else if(currentLevel.levelWon) {
            SetLevel((uint) levelIndex + 1);
        }else {
            currentLevel.Update();
        }
        _hud.Update();
    }

    /// <summary>
    /// Loads and sets the next level.
    /// </summary>
    /// <param name="index">Index of the level to be set.</param>
    private void SetLevel(uint index) {
        if(index >= levelCount) {
            GameSystem.currentScene = new MainMenuScene();
            return;
        }
        levelIndex = (int) index;

        currentLevel = new LevelScene([new TickUpdateSystem(), new CollisionSystem(), new ItemCollectionSystem()], LevelLoader.LoadFromYaml(LevelListPath, levelIndex));
    }
}