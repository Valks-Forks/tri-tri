using Godot;
using System;

public class CardScene : Spatial
{
	protected DigitPlate DigitPlate1 => GetNode<DigitPlate> (nameof (DigitPlate1));

	protected DigitPlate DigitPlate2 => GetNode<DigitPlate> (nameof (DigitPlate2));
	
	protected DigitPlate DigitPlate3 => GetNode<DigitPlate> (nameof (DigitPlate3));
	
	protected DigitPlate DigitPlate4 => GetNode<DigitPlate> (nameof (DigitPlate4));

	protected TexturedQuadMesh TexturedQuadMesh => GetNode<TexturedQuadMesh> (nameof (TexturedQuadMesh));

	protected ICard Card;

	string _cardName;

	[Export]
	public string CardName {
		get { return Card?.Name ?? _cardName; }
		set {
			_cardName = value;
			LoadCard ();
		}
	}

	void LoadCard ()
	{
		Card = CardDatabase.GetCard (_cardName);
		DigitPlate1.Digit = Card.Values [0];
		DigitPlate2.Digit = Card.Values [1];
		DigitPlate3.Digit = Card.Values [2];
		DigitPlate4.Digit = Card.Values [3];

		if (Card.Name != "none") {
			TexturedQuadMesh.Texture = GD.Load<StreamTexture> (Card.GetTextureFilename ());
		}
		else {
			TexturedQuadMesh.Texture = null;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		LoadCard ();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
	
	}
}
