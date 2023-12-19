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
    [DisplayOnly] public bool tree0 = false;
    [DisplayOnly] public bool tree1 = false;
    [DisplayOnly] public bool tree2 = false;

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
            "Cat-111: Messenger-107, this is really ...... amazing.",
            "M-107 (You): How do I go back to my home?",
            "Cat-111: Are you serious?",
            "Cat-111: It's not easy to go home.",
            "M-107 (You): You think I like being here?",
            "Cat-111: Uh ......, I don't hate it.",
            "Cat-111: Look at all those cute little kittens on my planet.",
            "Cat-111: Anyway, I can't help you.",
            "Cat-111: But there's a mysterious ocean star in the neighborhood.",
            @"Cat-111: There's liquid water so far away from the sun.
What is the heat source?",
            "Cat-111: Maybe you could look around."
        },
        // fishFirstTalk - 2
        new List<string>() {
            "CatFish: Who's that coming?",
            "M-107 (You): I'm a Venusian from the far solar system.",
            "M-107 (You): I was ordered to come to Planet O to get the 'Gensokyo', but I was unexpectedly trapped by this sudden blackhole.",
            "M-107 (You): I want to go home, can you help me?",
            "CatFish: This sudden gravitational pull has changed the entire ecology of Oceanus.",
            "CatFish: The originally docile blue whale has suddenly become violent, attacking visitors whenever he sees them, which was not the case in the past.",
            "M-107 (You): Do you know why the blackhole suddenly appear in this galaxy?",
            "M-107 (You): It's so strange. It doesn't fit the perceived physics.",
            "CatFish: It's those damn earthlings who are always pursuing their own technological advancement while ignoring the ecological balance of the universe and don't care about other living beings.",
            "M-107 (You): That's right. The Earthlings are disgusting.",
            "M-107 (You): We Venusians are trying to avoid being colonized by Earthlings,so right now we're at war with them.",
            "M-107 (You): So I had to finish my mission quickly to get back to Venus for support.",
            "CatFish: Looks like you're in a big hurry to get out of here.",
            "CatFish: But I've been living here for centuries, and I can't think of a good way to help you get out of this weird gravitational field.",
            "CatFish: Why don't you go look at the Labyrinth in the distance?",
            "CatFish: But I must warn you, you have to be careful",
            "M-107 (You): As the saying goes, nothing can stop a Venusian."
        },
        // beforeFall - 3
        new List<string>() {
            "M-107 (You): Is that catfish lying to me? There's nothing on this planet.",
            "M-107 (You): And it's super hard to get around."
        },
        // afterFall - 4
        new List<string>() {
            "M-107 (You): Is this the legendary Labyrinth Star?",
            "M-107 (You): I need to get closer to the planet's core."
        },
        // nearDragon - 5
        new List<string>() {
            "M-107 (You): Why am I here? Am I not inside the Labyrinth?",
            "M-107 (You): Anyway, I'll check out the planet first."
        },
        // touchCrystal - 6
        new List<string>() {
            "M-107 (You): ...... !?!?",
        },
        // yermengard - 7
        new List<string>() {
            "Yermengard: Whoever broke my peace, I'll make him pay.",
            "M-107 (You): Run away!"
        },
        // tryToRun - 8
        new List<string>() {
            "M-107 (You): Ah!? Or do I have to take this huge thing. With the black hole?"
        },
    };

    public List<List<string>> treeSubtitles = new List<List<string>>() {
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
