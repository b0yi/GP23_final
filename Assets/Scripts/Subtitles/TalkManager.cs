using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatTalkState {
    FirstTalk,
    // KeepTalk,
    // WaterTalk,
    // FishTalk,
    NoTalk
}

public class TalkManager : MonoBehaviour
{
    public int currentSubtitle = 0;
    [DisplayOnly] public List<bool> treeBools = new List<bool>() {
        false, // tree 0
        false, // tree 1
        false, // tree 2
        false  // tree 3
    };

    public List<List<string>> subtitles = new List<List<string>>() {
        // steleInfo - 0
        new List<string>() {
            "No one in sight.",
            "Go to Litter Box Star",
            "Hold 'W' to launch." 
        },
        // catFirstTalk - 1
        new List<string>() {
            "Cat-111: My God, a living Venusian!",
            "Cat-111: Messenger-107, this is truly amazing.",
            "M-107 (You): How do I return home?",
            "Cat-111: Are you serious?",
            "Cat-111: It's not easy to leave.",
            "M-107 (You): Do you think I like being here?",
            "Cat-111: Uh, I don't hate it.",
            "Cat-111: Look at those cute kittens on my planet.",
            "Cat-111: Anyway, I can't help you.",
            "Cat-111: I can't help, but there's a mysterious ocean star nearby.",
            "Cat-111: Explore it, maybe you'll find your answers."
        },
        // fishFirstTalk - 2
        new List<string>() {
            "CatFish: Who's approaching?",
            "M-107 (You): I'm from Venus, stranded with a mission to retrieve 'extrenergy fluid.'",
            @"M-107 (You): I urgently need to escape the gravitational pull of a black hole to back home.
Can you assist me?",
            @"CatFish: The gravitational pull changed Oceanus.
Blue whales are aggressive now.",
            "CatFish: Earthlings caused it, ignoring universal balance.",
            "M-107 (You): They're disgusting. We're at war with them.",
            "M-107 (You): I must finish my mission to return to Venus for support.",
            "M-107 (You): Catfish, any clues? I can't navigate this gravitational field.",
            "CatFish: Check the distant Labyrinth, but beware.",
        },
        // beforeFall - 3
        new List<string>() {
            "M-107 (You): Is that catfish lying to me? There's nothing on this planet.",
            "M-107 (You): And it's super hard to get around."
        },
        // afterFall - 4
        new List<string>() {
            "M-107 (You): Is this the Labyrinth Star?",
            "M-107 (You): I must reach the planet's core."
        },
        // nearDragon - 5
        new List<string>() {
            "M-107 (You): Why am I here? Isn't this the Labyrinth?",
            "M-107 (You): Regardless, I'll explore."
        },
        // touchCrystal - 6
        new List<string>() {
            "M-107 (You): ...... !?!?",
        },
        // yermengard - 7
        new List<string>() {
            "Yermengard: Who disturbed my peace will pay.",
            "M-107 (You): Run!"
        },
        // maybeDie2Times - 8
        new List<string>() {
            "M-107 (You): Or do I use this giant with the black hole?"
        },
    };

    public List<List<string>> treeSubtitles = new List<List<string>>() {
        // tree 0
        new List<string>() {
            "This is the Energy Extraction tree planted by the Venusians to obtain energy called ‘extrenergy fluid’.",
        },
        // tree 1
        new List<string>() {
            "The life force, extrenergy fluid, is fading.",
        },
        // tree 2
        new List<string>() {
            "For centuries, trees extracted extrenergy fluid, but the planet is dying.",
        },
        // tree 3
        new List<string>() {
            "This planet is in its final days.",
        }
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
