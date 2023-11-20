# Circle Generator
## Quick-start guide

1. Install the package.
1. Inside the Unity Editor, go to GameObject > 2D Object. Pick one of the Circle Generator options. This will create a new GameObject with a Circle Generator component.
1. Within the Editor, edit the parameters on the component to the desired state. You should see these changes appear in the scene in Editor-mode.
1. Set a material. Note: CircleGenerator does not come with materials; please provide your own.

Keep reading for a more in-depth overview.

## What is Circle Generator?

Circle Generator allows the creation of 2D circles, designed to be used in Unity's 2D mode (although with a bit of creativity I'm sure it could work in 3D mode too).

### What problem does it solve?

I wanted a way of creating adjustable 2D circles on the fly. A game I'm working on (Zen Hop) required circles that could be adjusted programmatically and extensively. Unity didn't seem to have this option built-in, so I created a component that could easily be reused.

### Features

Circle Generator allows circles to be editable in editor mode through the Unity Editor through the setting of various parameters. It also allows circles to be created and adjusted dynamically through scripting.

## Unity Editor Parameters

These are the parameters available for editing in the Unity Editor.

### Circle Data

Circle Data is necessary for all circles.

| Parameter  | Description  |
|:----------|:----------|
| Radius    | Defines the radius of the circle. This is the distance from the centre of the circle to its inner edge and does not include its border. A radius of 1 is equal to one grid square in the Unity Editor. Cannot be a negative number.    |
| Completion    | Defines a portion of the circle to be rendered, given in degrees. For example, to render a quarter of the circle, use a value of 90. Can range from 0 to 360.    |
| Angle    | Defines the rotation of the circle. Can range from 0 to 360.    |
| Polygon Quantity    | Defines the number of polygons to use when generating the circle. The minimum amount is 3, which would result in a triangular object. The number is arbitrarily capped at 360 as a safety feature to prevent accidental increase beyond the machine's capabilities. The more polygons, the smoother the circle will appear, at an expense in performance, depending on the machine's power.    |
| Keep Polygon Quantity Consistent    | Toggle the ability to change Circle Generator's internal polygon count depending on the Completion value. For example, when set to true, with a Polygon Quantity set to 60, and with a Completion of 90, the polygon quantity will reduce by roughly 1/4 to around 15. When set to false, no such reduction in polygon count will happen and polygon count will remain at 60. It is recommended to keep this set to true.    |

### Stroke Data

Stroke Data is only necessary on Stroke and Dash circles.

| Parameter  | Description  |
|:----------|:----------|
| Stroke Size    | Defines the size of the "stroke" or the "border" of the circle. Like the radius, a value of 1 is equal to one Unity Editor grid square. Cannot be a negative number.    |
| Keep Stroke Size Relative    | Toggle the ability to make the stroke size increase or decrease in proportion to the radius of the circle. When set to true, the stroke size will change as the radius changes. This is useful if you want to keep the stroke proportionate to the circle while changing the radius. When set to false, the stroke size will always remain constant, no matter the radius.    |

## API Overview

You may interface with CircleGenerator purely through scripting if you so wish.

The simplest way to do so is through the `MonoBehaviour`s which inherit from `CircleGenerator`. These are `DashCircleGenerator`, `FillCircleGenerator`, and `StrokeCircleGenerator`.

In order to interact with them, first set their data by passing in a `CircleData` object (and if they're of the 'dash' or 'stroke' variety, a `StrokeData` object) to the `CircleData` and `StrokeData` properties, respectively.

You may then call `Generate()` to update the attached mesh.

The `CircleData` and `StrokeData` class constructors take all the same arguments mentioned above in the Unity Editor Parameters section.

## Support

To get in touch regarding support-related issues, go to [robingoodfellowdev.wordpress.com](https://robingoodfellowdev.wordpress.com), or email me at [robin.goodfellow.dev@gmail.com](mailto:robin.goodfellow.dev@gmail.com).
