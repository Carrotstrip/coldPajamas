// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""f0d7fb5d-fe9f-4ffd-89a6-a3f24443d922"",
            ""actions"": [
                {
                    ""name"": ""LookStick"",
                    ""type"": ""Value"",
                    ""id"": ""fa80c71d-c786-4bac-b44a-d35f7bceabd5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""39e58983-70db-42e4-bdb1-b032066b8699"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""d907148e-66cb-420b-b0ef-e77dd32f7498"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""0d1bd854-01e3-46f9-aa4b-806df76b3fd5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""5a06a457-1189-4f53-88a4-7e9ed4603020"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""154f834d-4f1b-41e6-9bbe-999493361e2b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""426c9322-7ef4-47d6-8f1e-8656b717284d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""984386e1-d6a9-40ea-a420-f1f905654b9a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LT"",
                    ""type"": ""Button"",
                    ""id"": ""7413fb19-e103-47d1-8bc0-c55ff8771c74"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""aae26291-28be-49af-b8e9-5cb041eb0b82"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LTUp"",
                    ""type"": ""Button"",
                    ""id"": ""5ae5a9c9-43e6-42fd-9eb6-11edef2dd432"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LBUp"",
                    ""type"": ""Button"",
                    ""id"": ""0cd4823e-4733-40d3-a83d-70179c439dac"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AUp"",
                    ""type"": ""Button"",
                    ""id"": ""379ec654-2979-4edb-8845-44751f6a8dc5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sail"",
                    ""type"": ""Value"",
                    ""id"": ""cba59853-cbd6-458d-a01f-91a0f9abe8a4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c1f7a91b-d0fd-4a62-997e-7fb9b69bf235"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""LookStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""143bb1cd-cc10-4eca-a2f0-a3664166fe91"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee3d0cd2-254e-47a7-a8cb-bc94d9658c54"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8b4cd31-e76e-46d0-abc4-f80efb633a9c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e08b954d-f0f2-4b69-a108-6adf0e3f5fa1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e90b0ab2-4269-4062-8fdd-27861d3b20c8"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ba72415-170d-474b-ba21-894527c2047a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d2ee77d-b54e-4cd2-8af4-75c2d9a8b9a3"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f65754d6-644f-451c-bd3b-935b04a8bb47"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4df5befe-caf1-426a-91c3-929de89ed7a7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5414e07-8a5c-4aae-89bd-1a33d8dd7481"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78228ec6-70f2-488b-93d5-d5be64ff27f9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LTUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1793c4fa-eabb-433c-8cdd-9cb61bed741e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LBUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff98759b-1023-41f1-b200-312272bd1596"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e85d1e6a-af88-4b91-9799-f513b842a06f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sail"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Fishing"",
            ""id"": ""2fa96281-80f2-4a1d-bf72-1e29515308eb"",
            ""actions"": [
                {
                    ""name"": ""RightStick2"",
                    ""type"": ""PassThrough"",
                    ""id"": ""efa75387-dd63-41ee-a7ca-813d5f30d630"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Value"",
                    ""id"": ""bbc94337-c256-43d8-b883-115d7f46d069"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""d16420c4-e558-4fd0-a193-d97320684d93"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ee3f0daf-e47c-43e5-b2c3-0f33ce26f6c2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""RightStick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a26bf98a-dedc-4749-90aa-add46bfb7a30"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbb2deef-a72a-45a5-863f-137850039732"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""89875a6f-5498-4f59-8859-92e22e73a3c9"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""2bff02cd-d534-4838-8418-4b8b2d718990"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""8f232b06-d8e7-4549-ab99-66c1cb2d2a5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""2eecf6cb-bac6-4cf8-b95e-98f0960d9887"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e40026e4-4a28-421f-b256-c22bb05674a7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""15baf0a4-c8bd-42a4-a6d6-609dfc1e7efa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c2531993-a6bd-4bac-9093-2099f095bdb9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""50063c23-28eb-4622-8799-a8aa6dbe0c43"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2d292d64-8b44-4613-83a2-7b7ba453826b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bcfce85a-7496-4251-8a36-d2eafe77bd1e"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c2dbc1e0-f5bd-44b8-b8ca-7b50720db0f3"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a080f563-a08a-4b1d-b69c-0d2d093a3301"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""6493de21-3c5b-4739-8eff-a1ee4a01777b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""352c8b3f-5d89-4145-8cc7-b120763dabda"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveCursor"",
                    ""type"": ""Button"",
                    ""id"": ""474fbd92-8ead-4b6f-a770-5450e00999ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c785093b-5b7b-44c5-8cbc-3b7fb87bfd33"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37c83d38-51a7-46df-8e12-6c535c474df8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bd7221b-35bb-4dea-8b66-bd79ee3f9d94"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ba53853-73b9-4d67-a929-68ca2ce5a37e"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2a232ff-c1db-4bfc-b73a-38b468d9be47"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1284ab7-69d4-4fc1-b0ea-a7ef0815fd1d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a59bfdb-216b-4839-bfc7-4241bb78590f"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1f4dce0-fb6f-4701-b6aa-2ecea0f9d89c"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95c05618-3f96-4b9c-b066-ba65b2ffbced"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71e81fb5-507c-4c44-99cc-11d23b8e6365"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29df78b7-a7a3-465f-841f-7e2626405eca"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12246555-eb78-4424-98a1-b9a2431c72c8"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd365283-d857-4093-ada8-848f9c7792bd"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b6e9a37-1258-48a4-af25-d792bfc21b33"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDeviceSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17fb0344-b2a4-426a-adf6-cacd430b395e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8494969e-bcd2-4f76-a61b-40e3606deaa0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e814539-1600-4d0a-895f-70a546454a2e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Join"",
            ""id"": ""0cabbf5f-d9d0-48d5-9feb-7b50afc9f038"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""696bbee2-70bf-4372-85aa-3321932f7a5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""892a15c7-64fb-4ccb-9106-dddeae12b7be"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b2503bc8-2795-4fcd-ab00-6de73737a4c7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d93a3178-d19e-424e-bbf4-b027c2be1578"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""c845c0e7-21dd-40f2-874c-7f8932c5a085"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""dd49db28-58de-44c0-927e-1fc984ffa214"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""50658e0d-3d89-4df7-91f2-3afee7e5a82a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7874dd3d-f176-47d2-aab7-92450a14d6e4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02b393a1-bf6b-4d12-b3bf-98b88702fee2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_LookStick = m_Player.FindAction("LookStick", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Y = m_Player.FindAction("Y", throwIfNotFound: true);
        m_Player_A = m_Player.FindAction("A", throwIfNotFound: true);
        m_Player_X = m_Player.FindAction("X", throwIfNotFound: true);
        m_Player_B = m_Player.FindAction("B", throwIfNotFound: true);
        m_Player_StartButton = m_Player.FindAction("StartButton", throwIfNotFound: true);
        m_Player_RT = m_Player.FindAction("RT", throwIfNotFound: true);
        m_Player_LT = m_Player.FindAction("LT", throwIfNotFound: true);
        m_Player_LB = m_Player.FindAction("LB", throwIfNotFound: true);
        m_Player_LTUp = m_Player.FindAction("LTUp", throwIfNotFound: true);
        m_Player_LBUp = m_Player.FindAction("LBUp", throwIfNotFound: true);
        m_Player_AUp = m_Player.FindAction("AUp", throwIfNotFound: true);
        m_Player_Sail = m_Player.FindAction("Sail", throwIfNotFound: true);
        // Fishing
        m_Fishing = asset.FindActionMap("Fishing", throwIfNotFound: true);
        m_Fishing_RightStick2 = m_Fishing.FindAction("RightStick2", throwIfNotFound: true);
        m_Fishing_RightStick = m_Fishing.FindAction("RightStick", throwIfNotFound: true);
        m_Fishing_StartButton = m_Fishing.FindAction("StartButton", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        m_UI_TrackedDeviceSelect = m_UI.FindAction("TrackedDeviceSelect", throwIfNotFound: true);
        m_UI_X = m_UI.FindAction("X", throwIfNotFound: true);
        m_UI_B = m_UI.FindAction("B", throwIfNotFound: true);
        m_UI_MoveCursor = m_UI.FindAction("MoveCursor", throwIfNotFound: true);
        // Join
        m_Join = asset.FindActionMap("Join", throwIfNotFound: true);
        m_Join_A = m_Join.FindAction("A", throwIfNotFound: true);
        m_Join_Start = m_Join.FindAction("Start", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_A = m_Menu.FindAction("A", throwIfNotFound: true);
        m_Menu_B = m_Menu.FindAction("B", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_LookStick;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Y;
    private readonly InputAction m_Player_A;
    private readonly InputAction m_Player_X;
    private readonly InputAction m_Player_B;
    private readonly InputAction m_Player_StartButton;
    private readonly InputAction m_Player_RT;
    private readonly InputAction m_Player_LT;
    private readonly InputAction m_Player_LB;
    private readonly InputAction m_Player_LTUp;
    private readonly InputAction m_Player_LBUp;
    private readonly InputAction m_Player_AUp;
    private readonly InputAction m_Player_Sail;
    public struct PlayerActions
    {
        private InputActions m_Wrapper;
        public PlayerActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LookStick => m_Wrapper.m_Player_LookStick;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Y => m_Wrapper.m_Player_Y;
        public InputAction @A => m_Wrapper.m_Player_A;
        public InputAction @X => m_Wrapper.m_Player_X;
        public InputAction @B => m_Wrapper.m_Player_B;
        public InputAction @StartButton => m_Wrapper.m_Player_StartButton;
        public InputAction @RT => m_Wrapper.m_Player_RT;
        public InputAction @LT => m_Wrapper.m_Player_LT;
        public InputAction @LB => m_Wrapper.m_Player_LB;
        public InputAction @LTUp => m_Wrapper.m_Player_LTUp;
        public InputAction @LBUp => m_Wrapper.m_Player_LBUp;
        public InputAction @AUp => m_Wrapper.m_Player_AUp;
        public InputAction @Sail => m_Wrapper.m_Player_Sail;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                LookStick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookStick;
                LookStick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookStick;
                LookStick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookStick;
                Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                Y.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnY;
                Y.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnY;
                Y.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnY;
                A.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                A.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                A.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                X.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnX;
                X.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnX;
                X.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnX;
                B.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnB;
                B.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnB;
                B.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnB;
                StartButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
                StartButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
                StartButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
                RT.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRT;
                RT.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRT;
                RT.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRT;
                LT.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLT;
                LT.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLT;
                LT.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLT;
                LB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLB;
                LB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLB;
                LB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLB;
                LTUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLTUp;
                LTUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLTUp;
                LTUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLTUp;
                LBUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLBUp;
                LBUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLBUp;
                LBUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLBUp;
                AUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAUp;
                AUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAUp;
                AUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAUp;
                Sail.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSail;
                Sail.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSail;
                Sail.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSail;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                LookStick.started += instance.OnLookStick;
                LookStick.performed += instance.OnLookStick;
                LookStick.canceled += instance.OnLookStick;
                Fire.started += instance.OnFire;
                Fire.performed += instance.OnFire;
                Fire.canceled += instance.OnFire;
                Y.started += instance.OnY;
                Y.performed += instance.OnY;
                Y.canceled += instance.OnY;
                A.started += instance.OnA;
                A.performed += instance.OnA;
                A.canceled += instance.OnA;
                X.started += instance.OnX;
                X.performed += instance.OnX;
                X.canceled += instance.OnX;
                B.started += instance.OnB;
                B.performed += instance.OnB;
                B.canceled += instance.OnB;
                StartButton.started += instance.OnStartButton;
                StartButton.performed += instance.OnStartButton;
                StartButton.canceled += instance.OnStartButton;
                RT.started += instance.OnRT;
                RT.performed += instance.OnRT;
                RT.canceled += instance.OnRT;
                LT.started += instance.OnLT;
                LT.performed += instance.OnLT;
                LT.canceled += instance.OnLT;
                LB.started += instance.OnLB;
                LB.performed += instance.OnLB;
                LB.canceled += instance.OnLB;
                LTUp.started += instance.OnLTUp;
                LTUp.performed += instance.OnLTUp;
                LTUp.canceled += instance.OnLTUp;
                LBUp.started += instance.OnLBUp;
                LBUp.performed += instance.OnLBUp;
                LBUp.canceled += instance.OnLBUp;
                AUp.started += instance.OnAUp;
                AUp.performed += instance.OnAUp;
                AUp.canceled += instance.OnAUp;
                Sail.started += instance.OnSail;
                Sail.performed += instance.OnSail;
                Sail.canceled += instance.OnSail;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Fishing
    private readonly InputActionMap m_Fishing;
    private IFishingActions m_FishingActionsCallbackInterface;
    private readonly InputAction m_Fishing_RightStick2;
    private readonly InputAction m_Fishing_RightStick;
    private readonly InputAction m_Fishing_StartButton;
    public struct FishingActions
    {
        private InputActions m_Wrapper;
        public FishingActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightStick2 => m_Wrapper.m_Fishing_RightStick2;
        public InputAction @RightStick => m_Wrapper.m_Fishing_RightStick;
        public InputAction @StartButton => m_Wrapper.m_Fishing_StartButton;
        public InputActionMap Get() { return m_Wrapper.m_Fishing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FishingActions set) { return set.Get(); }
        public void SetCallbacks(IFishingActions instance)
        {
            if (m_Wrapper.m_FishingActionsCallbackInterface != null)
            {
                RightStick2.started -= m_Wrapper.m_FishingActionsCallbackInterface.OnRightStick2;
                RightStick2.performed -= m_Wrapper.m_FishingActionsCallbackInterface.OnRightStick2;
                RightStick2.canceled -= m_Wrapper.m_FishingActionsCallbackInterface.OnRightStick2;
                RightStick.started -= m_Wrapper.m_FishingActionsCallbackInterface.OnRightStick;
                RightStick.performed -= m_Wrapper.m_FishingActionsCallbackInterface.OnRightStick;
                RightStick.canceled -= m_Wrapper.m_FishingActionsCallbackInterface.OnRightStick;
                StartButton.started -= m_Wrapper.m_FishingActionsCallbackInterface.OnStartButton;
                StartButton.performed -= m_Wrapper.m_FishingActionsCallbackInterface.OnStartButton;
                StartButton.canceled -= m_Wrapper.m_FishingActionsCallbackInterface.OnStartButton;
            }
            m_Wrapper.m_FishingActionsCallbackInterface = instance;
            if (instance != null)
            {
                RightStick2.started += instance.OnRightStick2;
                RightStick2.performed += instance.OnRightStick2;
                RightStick2.canceled += instance.OnRightStick2;
                RightStick.started += instance.OnRightStick;
                RightStick.performed += instance.OnRightStick;
                RightStick.canceled += instance.OnRightStick;
                StartButton.started += instance.OnStartButton;
                StartButton.performed += instance.OnStartButton;
                StartButton.canceled += instance.OnStartButton;
            }
        }
    }
    public FishingActions @Fishing => new FishingActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    private readonly InputAction m_UI_TrackedDeviceSelect;
    private readonly InputAction m_UI_X;
    private readonly InputAction m_UI_B;
    private readonly InputAction m_UI_MoveCursor;
    public struct UIActions
    {
        private InputActions m_Wrapper;
        public UIActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputAction @TrackedDeviceSelect => m_Wrapper.m_UI_TrackedDeviceSelect;
        public InputAction @X => m_Wrapper.m_UI_X;
        public InputAction @B => m_Wrapper.m_UI_B;
        public InputAction @MoveCursor => m_Wrapper.m_UI_MoveCursor;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceSelect.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                TrackedDeviceSelect.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                TrackedDeviceSelect.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                X.started -= m_Wrapper.m_UIActionsCallbackInterface.OnX;
                X.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnX;
                X.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnX;
                B.started -= m_Wrapper.m_UIActionsCallbackInterface.OnB;
                B.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnB;
                B.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnB;
                MoveCursor.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveCursor;
                MoveCursor.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveCursor;
                MoveCursor.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveCursor;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                Navigate.started += instance.OnNavigate;
                Navigate.performed += instance.OnNavigate;
                Navigate.canceled += instance.OnNavigate;
                Submit.started += instance.OnSubmit;
                Submit.performed += instance.OnSubmit;
                Submit.canceled += instance.OnSubmit;
                Cancel.started += instance.OnCancel;
                Cancel.performed += instance.OnCancel;
                Cancel.canceled += instance.OnCancel;
                Point.started += instance.OnPoint;
                Point.performed += instance.OnPoint;
                Point.canceled += instance.OnPoint;
                Click.started += instance.OnClick;
                Click.performed += instance.OnClick;
                Click.canceled += instance.OnClick;
                ScrollWheel.started += instance.OnScrollWheel;
                ScrollWheel.performed += instance.OnScrollWheel;
                ScrollWheel.canceled += instance.OnScrollWheel;
                MiddleClick.started += instance.OnMiddleClick;
                MiddleClick.performed += instance.OnMiddleClick;
                MiddleClick.canceled += instance.OnMiddleClick;
                RightClick.started += instance.OnRightClick;
                RightClick.performed += instance.OnRightClick;
                RightClick.canceled += instance.OnRightClick;
                TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                TrackedDeviceSelect.started += instance.OnTrackedDeviceSelect;
                TrackedDeviceSelect.performed += instance.OnTrackedDeviceSelect;
                TrackedDeviceSelect.canceled += instance.OnTrackedDeviceSelect;
                X.started += instance.OnX;
                X.performed += instance.OnX;
                X.canceled += instance.OnX;
                B.started += instance.OnB;
                B.performed += instance.OnB;
                B.canceled += instance.OnB;
                MoveCursor.started += instance.OnMoveCursor;
                MoveCursor.performed += instance.OnMoveCursor;
                MoveCursor.canceled += instance.OnMoveCursor;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Join
    private readonly InputActionMap m_Join;
    private IJoinActions m_JoinActionsCallbackInterface;
    private readonly InputAction m_Join_A;
    private readonly InputAction m_Join_Start;
    public struct JoinActions
    {
        private InputActions m_Wrapper;
        public JoinActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_Join_A;
        public InputAction @Start => m_Wrapper.m_Join_Start;
        public InputActionMap Get() { return m_Wrapper.m_Join; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JoinActions set) { return set.Get(); }
        public void SetCallbacks(IJoinActions instance)
        {
            if (m_Wrapper.m_JoinActionsCallbackInterface != null)
            {
                A.started -= m_Wrapper.m_JoinActionsCallbackInterface.OnA;
                A.performed -= m_Wrapper.m_JoinActionsCallbackInterface.OnA;
                A.canceled -= m_Wrapper.m_JoinActionsCallbackInterface.OnA;
                Start.started -= m_Wrapper.m_JoinActionsCallbackInterface.OnStart;
                Start.performed -= m_Wrapper.m_JoinActionsCallbackInterface.OnStart;
                Start.canceled -= m_Wrapper.m_JoinActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_JoinActionsCallbackInterface = instance;
            if (instance != null)
            {
                A.started += instance.OnA;
                A.performed += instance.OnA;
                A.canceled += instance.OnA;
                Start.started += instance.OnStart;
                Start.performed += instance.OnStart;
                Start.canceled += instance.OnStart;
            }
        }
    }
    public JoinActions @Join => new JoinActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_A;
    private readonly InputAction m_Menu_B;
    public struct MenuActions
    {
        private InputActions m_Wrapper;
        public MenuActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_Menu_A;
        public InputAction @B => m_Wrapper.m_Menu_B;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                A.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnA;
                A.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnA;
                A.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnA;
                B.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnB;
                B.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnB;
                B.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnB;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                A.started += instance.OnA;
                A.performed += instance.OnA;
                A.canceled += instance.OnA;
                B.started += instance.OnB;
                B.performed += instance.OnB;
                B.canceled += instance.OnB;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnLookStick(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnLT(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
        void OnLTUp(InputAction.CallbackContext context);
        void OnLBUp(InputAction.CallbackContext context);
        void OnAUp(InputAction.CallbackContext context);
        void OnSail(InputAction.CallbackContext context);
    }
    public interface IFishingActions
    {
        void OnRightStick2(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        void OnTrackedDeviceSelect(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnMoveCursor(InputAction.CallbackContext context);
    }
    public interface IJoinActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
    }
}
