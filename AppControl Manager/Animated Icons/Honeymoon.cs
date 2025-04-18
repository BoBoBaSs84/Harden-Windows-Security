//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//       LottieGen version:
//           8.1.240821.1+077322fa26
//       
//       Command:
//           LottieGen -Language CSharp -Public -WinUIVersion 3.0 -InputFile honeymoon.json
//       
//       Input file:
//           honeymoon.json (170740 bytes created 11:30+02:00 Mar 10 2025)
//       
//       LottieGen source:
//           http://aka.ms/Lottie
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// ____________________________________
// |       Object stats       | Count |
// |__________________________|_______|
// | All CompositionObjects   |   102 |
// |--------------------------+-------|
// | Expression animators     |     2 |
// | KeyFrame animators       |     5 |
// | Reference parameters     |     3 |
// | Expression operations    |     0 |
// |--------------------------+-------|
// | Animated brushes         |     - |
// | Animated gradient stops  |     - |
// | ExpressionAnimations     |     1 |
// | PathKeyFrameAnimations   |     - |
// |--------------------------+-------|
// | ContainerVisuals         |     1 |
// | ShapeVisuals             |     1 |
// |--------------------------+-------|
// | ContainerShapes          |     2 |
// | CompositionSpriteShapes  |    23 |
// |--------------------------+-------|
// | Brushes                  |     6 |
// | Gradient stops           |     - |
// | CompositionVisualSurface |     - |
// ------------------------------------
using Microsoft.Graphics;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.UI.Composition;
using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.UI;

namespace AnimatedVisuals
{
	// Name:        honeymoon
	// Frame rate:  24 fps
	// Frame count: 28
	// Duration:    1166.7 mS
	// _____________________________________________________________________________________________
	// |           Marker           |           Constant           | Frame |   mS   |   Progress   |
	// |____________________________|______________________________|_______|________|______________|
	// | NormalToPressed_Start      | M_NormalToPressed_Start      |     0 |    0.0 | 0F           |
	// | NormalToPressed_End        | M_NormalToPressed_End        |     9 |  375.0 | 0.323214293F |
	// | PointerOverToPressed_Start | M_PointerOverToPressed_Start |     9 |  375.0 | 0.323214293F |
	// | PointerOverToPressed_End   | M_PointerOverToPressed_End   |    19 |  791.7 | 0.680357158F |
	// | PressedToNormal_Start      | M_PressedToNormal_Start      |    20 |  833.3 | 0.716071427F |
	// | PressedToNormal_End        | M_PressedToNormal_End        |    28 | 1166.7 | 1F           |
	// | PressedToPointerOver_Start | M_PressedToPointerOver_Start |    28 | 1166.7 | 1F           |
	// | PressedToPointerOver_End   | M_PressedToPointerOver_End   |    28 | 1166.7 | 1F           |
	// ---------------------------------------------------------------------------------------------
	sealed partial class Honeymoon
		: Microsoft.UI.Xaml.Controls.IAnimatedVisualSource
		, Microsoft.UI.Xaml.Controls.IAnimatedVisualSource2
	{
		// Animation duration: 1.167 seconds.
		internal const long c_durationTicks = 11666666;

		// Marker: NormalToPressed_Start.
		internal const float M_NormalToPressed_Start = 0F;

		// Marker: NormalToPressed_End.
		internal const float M_NormalToPressed_End = 0.323214293F;

		// Marker: PointerOverToPressed_Start.
		internal const float M_PointerOverToPressed_Start = 0.323214293F;

		// Marker: PointerOverToPressed_End.
		internal const float M_PointerOverToPressed_End = 0.680357158F;

		// Marker: PressedToNormal_Start.
		internal const float M_PressedToNormal_Start = 0.716071427F;

		// Marker: PressedToNormal_End.
		internal const float M_PressedToNormal_End = 1F;

		// Marker: PressedToPointerOver_Start.
		internal const float M_PressedToPointerOver_Start = 1F;

		// Marker: PressedToPointerOver_End.
		internal const float M_PressedToPointerOver_End = 1F;

		public Microsoft.UI.Xaml.Controls.IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor)
		{
			object ignored = null;
			return TryCreateAnimatedVisual(compositor, out ignored);
		}

		public Microsoft.UI.Xaml.Controls.IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor, out object diagnostics)
		{
			diagnostics = null;

			var res =
				new Honeymoon_AnimatedVisual(
					compositor
					);
			res.CreateAnimations();
			return res;
		}

		/// <summary>
		/// Gets the number of frames in the animation.
		/// </summary>
		public double FrameCount => 28d;

		/// <summary>
		/// Gets the frame rate of the animation.
		/// </summary>
		public double Framerate => 24d;

		/// <summary>
		/// Gets the duration of the animation.
		/// </summary>
		public TimeSpan Duration => TimeSpan.FromTicks(11666666);

		/// <summary>
		/// Converts a zero-based frame number to the corresponding progress value denoting the
		/// start of the frame.
		/// </summary>
		public double FrameToProgress(double frameNumber)
		{
			return frameNumber / 28d;
		}

		/// <summary>
		/// Returns a map from marker names to corresponding progress values.
		/// </summary>
		public IReadOnlyDictionary<string, double> Markers =>
			new Dictionary<string, double>
			{
				{ "NormalToPressed_Start", 0d },
				{ "NormalToPressed_End", 0.323214285714286 },
				{ "PointerOverToPressed_Start", 0.323214285714286 },
				{ "PointerOverToPressed_End", 0.680357142857143 },
				{ "PressedToNormal_Start", 0.716071428571429 },
				{ "PressedToNormal_End", 1d },
				{ "PressedToPointerOver_Start", 1d },
				{ "PressedToPointerOver_End", 1d },
			};

		/// <summary>
		/// Sets the color property with the given name, or does nothing if no such property
		/// exists.
		/// </summary>
		public void SetColorProperty(string propertyName, Color value)
		{
		}

		/// <summary>
		/// Sets the scalar property with the given name, or does nothing if no such property
		/// exists.
		/// </summary>
		public void SetScalarProperty(string propertyName, double value)
		{
		}

		sealed partial class Honeymoon_AnimatedVisual
			: Microsoft.UI.Xaml.Controls.IAnimatedVisual
			, Microsoft.UI.Xaml.Controls.IAnimatedVisual2
		{
			const long c_durationTicks = 11666666;
			readonly Compositor _c;
			readonly ExpressionAnimation _reusableExpressionAnimation;
			AnimationController _animationController_0;
			CompositionColorBrush _colorBrush_AlmostBrown_FFAC1356;
			CompositionColorBrush _colorBrush_AlmostCrimson_FFE91E62;
			CompositionColorBrush _colorBrush_AlmostDeepPink_FFFF4081;
			CompositionColorBrush _colorBrush_AlmostPink_FFF8BAD0;
			CompositionContainerShape _containerShape_0;
			CompositionContainerShape _containerShape_1;
			CompositionPathGeometry _pathGeometry_0;
			CompositionPathGeometry _pathGeometry_1;
			CompositionPathGeometry _pathGeometry_2;
			CompositionPathGeometry _pathGeometry_3;
			CompositionPathGeometry _pathGeometry_4;
			ContainerVisual _root;
			CubicBezierEasingFunction _cubicBezierEasingFunction_0;
			CubicBezierEasingFunction _cubicBezierEasingFunction_1;
			CubicBezierEasingFunction _cubicBezierEasingFunction_2;
			StepEasingFunction _holdThenStepEasingFunction;
			StepEasingFunction _stepThenHoldEasingFunction;

			void BindProperty(
				CompositionObject target,
				string animatedPropertyName,
				string expression,
				string referenceParameterName,
				CompositionObject referencedObject)
			{
				_reusableExpressionAnimation.ClearAllParameters();
				_reusableExpressionAnimation.Expression = expression;
				_reusableExpressionAnimation.SetReferenceParameter(referenceParameterName, referencedObject);
				target.StartAnimation(animatedPropertyName, _reusableExpressionAnimation);
			}

			ScalarKeyFrameAnimation CreateScalarKeyFrameAnimation(float initialProgress, float initialValue, CompositionEasingFunction initialEasingFunction)
			{
				var result = _c.CreateScalarKeyFrameAnimation();
				result.Duration = TimeSpan.FromTicks(c_durationTicks);
				result.InsertKeyFrame(initialProgress, initialValue, initialEasingFunction);
				return result;
			}

			Vector2KeyFrameAnimation CreateVector2KeyFrameAnimation(float initialProgress, Vector2 initialValue, CompositionEasingFunction initialEasingFunction)
			{
				var result = _c.CreateVector2KeyFrameAnimation();
				result.Duration = TimeSpan.FromTicks(c_durationTicks);
				result.InsertKeyFrame(initialProgress, initialValue, initialEasingFunction);
				return result;
			}

			CompositionSpriteShape CreateSpriteShape(CompositionGeometry geometry, Matrix3x2 transformMatrix, CompositionBrush fillBrush)
			{
				var result = _c.CreateSpriteShape(geometry);
				result.TransformMatrix = transformMatrix;
				result.FillBrush = fillBrush;
				return result;
			}

			AnimationController AnimationController_0()
			{
				if (_animationController_0 != null) { return _animationController_0; }
				var result = _animationController_0 = _c.CreateAnimationController();
				result.Pause();
				BindProperty(_animationController_0, "Progress", "_.Progress", "_", _root);
				return result;
			}

			CanvasGeometry Geometry_0()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(13.5F, -11F));
					builder.AddLine(new Vector2(-10.5F, -11F));
					builder.AddCubicBezier(new Vector2(-12.1999998F, -11F), new Vector2(-13.5F, -9.69999981F), new Vector2(-13.5F, -8F));
					builder.AddLine(new Vector2(-13.5F, 8F));
					builder.AddCubicBezier(new Vector2(-13.5F, 9.69999981F), new Vector2(-12.1999998F, 11F), new Vector2(-10.5F, 11F));
					builder.AddLine(new Vector2(13.5F, 11F));
					builder.AddLine(new Vector2(13.5F, -11F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			CanvasGeometry Geometry_1()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(5.5F, 11F));
					builder.AddLine(new Vector2(-8.5F, 11F));
					builder.AddLine(new Vector2(-8.5F, -11F));
					builder.AddLine(new Vector2(5.5F, -11F));
					builder.AddCubicBezier(new Vector2(7.19999981F, -11F), new Vector2(8.5F, -9.69999981F), new Vector2(8.5F, -8F));
					builder.AddLine(new Vector2(8.5F, 8F));
					builder.AddCubicBezier(new Vector2(8.5F, 9.69999981F), new Vector2(7.19999981F, 11F), new Vector2(5.5F, 11F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			CanvasGeometry Geometry_2()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(-1F, -1F));
					builder.AddLine(new Vector2(1F, -1F));
					builder.AddLine(new Vector2(1F, 1F));
					builder.AddLine(new Vector2(-1F, 1F));
					builder.AddLine(new Vector2(-1F, -1F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			CanvasGeometry Geometry_3()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(-4F, -1F));
					builder.AddLine(new Vector2(4F, -1F));
					builder.AddLine(new Vector2(4F, 1F));
					builder.AddLine(new Vector2(-4F, 1F));
					builder.AddLine(new Vector2(-4F, -1F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			CanvasGeometry Geometry_4()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(-1.5F, -1F));
					builder.AddLine(new Vector2(1.5F, -1F));
					builder.AddLine(new Vector2(1.5F, 1F));
					builder.AddLine(new Vector2(-1.5F, 1F));
					builder.AddLine(new Vector2(-1.5F, -1F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			// - - - - Layer aggregator
			// - - ShapeGroup: Group 7 Offset:<15.5, 24.5>
			CanvasGeometry Geometry_5()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(7.5F, -2.5F));
					builder.AddCubicBezier(new Vector2(7.5F, -4.70900011F), new Vector2(5.70900011F, -6.5F), new Vector2(3.5F, -6.5F));
					builder.AddCubicBezier(new Vector2(1.98199999F, -6.5F), new Vector2(0.677999973F, -5.64499998F), new Vector2(0F, -4.39900017F));
					builder.AddCubicBezier(new Vector2(-0.677999973F, -5.64499998F), new Vector2(-1.98199999F, -6.5F), new Vector2(-3.5F, -6.5F));
					builder.AddCubicBezier(new Vector2(-5.70900011F, -6.5F), new Vector2(-7.5F, -4.70900011F), new Vector2(-7.5F, -2.5F));
					builder.AddCubicBezier(new Vector2(-7.5F, -1.398F), new Vector2(-7.0539999F, -0.400999993F), new Vector2(-6.33400011F, 0.321999997F));
					builder.AddLine(new Vector2(-6.32700014F, 0.330000013F));
					builder.AddLine(new Vector2(0F, 6.5F));
					builder.AddLine(new Vector2(6.13399982F, 0.488999993F));
					builder.AddCubicBezier(new Vector2(6.96500015F, -0.244000003F), new Vector2(7.5F, -1.30499995F), new Vector2(7.5F, -2.5F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			CompositionColorBrush ColorBrush_AlmostBrown_FFAC1356()
			{
				return (_colorBrush_AlmostBrown_FFAC1356 == null)
					? _colorBrush_AlmostBrown_FFAC1356 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xAC, 0x13, 0x56))
					: _colorBrush_AlmostBrown_FFAC1356;
			}

			// - - Layer aggregator
			// ShapeGroup: Group 24 Offset:<36.5, 24>
			CompositionColorBrush ColorBrush_AlmostCrimson_FFD71B5F()
			{
				return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xD7, 0x1B, 0x5F));
			}

			CompositionColorBrush ColorBrush_AlmostCrimson_FFE91E62()
			{
				return (_colorBrush_AlmostCrimson_FFE91E62 == null)
					? _colorBrush_AlmostCrimson_FFE91E62 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xE9, 0x1E, 0x62))
					: _colorBrush_AlmostCrimson_FFE91E62;
			}

			CompositionColorBrush ColorBrush_AlmostDeepPink_FFFF4081()
			{
				return (_colorBrush_AlmostDeepPink_FFFF4081 == null)
					? _colorBrush_AlmostDeepPink_FFFF4081 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0x40, 0x81))
					: _colorBrush_AlmostDeepPink_FFFF4081;
			}

			// - - Layer aggregator
			// ShapeGroup: Group 25 Offset:<16.5, 24>
			CompositionColorBrush ColorBrush_AlmostHotPink_FFF48FB0()
			{
				return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xF4, 0x8F, 0xB0));
			}

			CompositionColorBrush ColorBrush_AlmostPink_FFF8BAD0()
			{
				return (_colorBrush_AlmostPink_FFF8BAD0 == null)
					? _colorBrush_AlmostPink_FFF8BAD0 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xF8, 0xBA, 0xD0))
					: _colorBrush_AlmostPink_FFF8BAD0;
			}

			// Layer aggregator
			CompositionContainerShape ContainerShape_0()
			{
				if (_containerShape_0 != null) { return _containerShape_0; }
				var result = _containerShape_0 = _c.CreateContainerShape();
				result.CenterPoint = new Vector2(3F, 35F);
				var shapes = result.Shapes;
				// ShapeGroup: Group 25 Offset:<16.5, 24>
				shapes.Add(SpriteShape_00());
				// ShapeGroup: Group 24 Offset:<36.5, 24>
				shapes.Add(SpriteShape_01());
				// ShapeGroup: Group 23 Offset:<29, 14>
				shapes.Add(SpriteShape_02());
				// ShapeGroup: Group 22 Offset:<29, 18>
				shapes.Add(SpriteShape_03());
				// ShapeGroup: Group 21 Offset:<29, 22>
				shapes.Add(SpriteShape_04());
				// ShapeGroup: Group 20 Offset:<29, 26>
				shapes.Add(SpriteShape_05());
				// ShapeGroup: Group 19 Offset:<29, 34>
				shapes.Add(SpriteShape_06());
				// ShapeGroup: Group 18 Offset:<29, 30>
				shapes.Add(SpriteShape_07());
				return result;
			}

			// Layer aggregator
			CompositionContainerShape ContainerShape_1()
			{
				if (_containerShape_1 != null) { return _containerShape_1; }
				var result = _containerShape_1 = _c.CreateContainerShape();
				result.CenterPoint = new Vector2(3F, 35F);
				var shapes = result.Shapes;
				// ShapeGroup: Group 17 Offset:<16.5, 24>
				shapes.Add(SpriteShape_08());
				// ShapeGroup: Group 16 Offset:<36.5, 24>
				shapes.Add(SpriteShape_09());
				// ShapeGroup: Group 15 Offset:<37, 26>
				shapes.Add(SpriteShape_10());
				// ShapeGroup: Group 14 Offset:<34.5, 22>
				shapes.Add(SpriteShape_11());
				// ShapeGroup: Group 13 Offset:<39.5, 22>
				shapes.Add(SpriteShape_12());
				// ShapeGroup: Group 12 Offset:<34.5, 30>
				shapes.Add(SpriteShape_13());
				// ShapeGroup: Group 11 Offset:<39.5, 30>
				shapes.Add(SpriteShape_14());
				// ShapeGroup: Group 7 Offset:<15.5, 24.5>
				shapes.Add(SpriteShape_15());
				// ShapeGroup: Group 10 Offset:<37, 18>
				shapes.Add(SpriteShape_16());
				// ShapeGroup: Group 6 Offset:<29, 14>
				shapes.Add(SpriteShape_17());
				// ShapeGroup: Group 5 Offset:<29, 18>
				shapes.Add(SpriteShape_18());
				// ShapeGroup: Group 4 Offset:<29, 22>
				shapes.Add(SpriteShape_19());
				// ShapeGroup: Group 3 Offset:<29, 26>
				shapes.Add(SpriteShape_20());
				// ShapeGroup: Group 2 Offset:<29, 34>
				shapes.Add(SpriteShape_21());
				// ShapeGroup: Group 1 Offset:<29, 30>
				shapes.Add(SpriteShape_22());
				return result;
			}

			CompositionPathGeometry PathGeometry_0()
			{
				return (_pathGeometry_0 == null)
					? _pathGeometry_0 = _c.CreatePathGeometry(new CompositionPath(Geometry_0()))
					: _pathGeometry_0;
			}

			CompositionPathGeometry PathGeometry_1()
			{
				return (_pathGeometry_1 == null)
					? _pathGeometry_1 = _c.CreatePathGeometry(new CompositionPath(Geometry_1()))
					: _pathGeometry_1;
			}

			CompositionPathGeometry PathGeometry_2()
			{
				return (_pathGeometry_2 == null)
					? _pathGeometry_2 = _c.CreatePathGeometry(new CompositionPath(Geometry_2()))
					: _pathGeometry_2;
			}

			CompositionPathGeometry PathGeometry_3()
			{
				return (_pathGeometry_3 == null)
					? _pathGeometry_3 = _c.CreatePathGeometry(new CompositionPath(Geometry_3()))
					: _pathGeometry_3;
			}

			CompositionPathGeometry PathGeometry_4()
			{
				return (_pathGeometry_4 == null)
					? _pathGeometry_4 = _c.CreatePathGeometry(new CompositionPath(Geometry_4()))
					: _pathGeometry_4;
			}

			// - - Layer aggregator
			// ShapeGroup: Group 7 Offset:<15.5, 24.5>
			CompositionPathGeometry PathGeometry_5()
			{
				return _c.CreatePathGeometry(new CompositionPath(Geometry_5()));
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_00()
			{
				// Offset:<16.5, 24>
				var geometry = PathGeometry_0();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 16.5F, 24F), ColorBrush_AlmostHotPink_FFF48FB0()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_01()
			{
				// Offset:<36.5, 24>
				var geometry = PathGeometry_1();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 36.5F, 24F), ColorBrush_AlmostCrimson_FFD71B5F()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_02()
			{
				// Offset:<29, 14>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 14F), ColorBrush_AlmostBrown_FFAC1356()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_03()
			{
				// Offset:<29, 18>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 18F), ColorBrush_AlmostBrown_FFAC1356()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_04()
			{
				// Offset:<29, 22>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 22F), ColorBrush_AlmostBrown_FFAC1356()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_05()
			{
				// Offset:<29, 26>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 26F), ColorBrush_AlmostBrown_FFAC1356()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_06()
			{
				// Offset:<29, 34>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 34F), ColorBrush_AlmostBrown_FFAC1356()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_07()
			{
				// Offset:<29, 30>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 30F), ColorBrush_AlmostBrown_FFAC1356()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_08()
			{
				// Offset:<16.5, 24>
				var geometry = PathGeometry_0();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 16.5F, 24F), ColorBrush_AlmostPink_FFF8BAD0()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_09()
			{
				// Offset:<36.5, 24>
				var geometry = PathGeometry_1();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 36.5F, 24F), ColorBrush_AlmostDeepPink_FFFF4081()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_10()
			{
				// Offset:<37, 26>
				var geometry = PathGeometry_3();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 37F, 26F), ColorBrush_AlmostPink_FFF8BAD0()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_11()
			{
				// Offset:<34.5, 22>
				var geometry = PathGeometry_4();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 34.5F, 22F), ColorBrush_AlmostPink_FFF8BAD0()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_12()
			{
				// Offset:<39.5, 22>
				var geometry = PathGeometry_4();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 39.5F, 22F), ColorBrush_AlmostPink_FFF8BAD0()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_13()
			{
				// Offset:<34.5, 30>
				var geometry = PathGeometry_4();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 34.5F, 30F), ColorBrush_AlmostPink_FFF8BAD0()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_14()
			{
				// Offset:<39.5, 30>
				var geometry = PathGeometry_4();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 39.5F, 30F), ColorBrush_AlmostPink_FFF8BAD0()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_15()
			{
				// Offset:<15.5, 24.5>
				var geometry = PathGeometry_5();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 15.5F, 24.5F), ColorBrush_AlmostDeepPink_FFFF4081()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_16()
			{
				// Offset:<37, 18>
				var geometry = PathGeometry_3();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 37F, 18F), ColorBrush_AlmostPink_FFF8BAD0()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_17()
			{
				// Offset:<29, 14>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 14F), ColorBrush_AlmostCrimson_FFE91E62()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_18()
			{
				// Offset:<29, 18>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 18F), ColorBrush_AlmostCrimson_FFE91E62()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_19()
			{
				// Offset:<29, 22>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 22F), ColorBrush_AlmostCrimson_FFE91E62()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_20()
			{
				// Offset:<29, 26>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 26F), ColorBrush_AlmostCrimson_FFE91E62()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_21()
			{
				// Offset:<29, 34>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 34F), ColorBrush_AlmostCrimson_FFE91E62()); ;
				return result;
			}

			// - Layer aggregator
			// Path 1
			CompositionSpriteShape SpriteShape_22()
			{
				// Offset:<29, 30>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 29F, 30F), ColorBrush_AlmostCrimson_FFE91E62()); ;
				return result;
			}

			// The root of the composition.
			ContainerVisual Root()
			{
				if (_root != null) { return _root; }
				var result = _root = _c.CreateContainerVisual();
				var propertySet = result.Properties;
				propertySet.InsertScalar("Progress", 0F);
				propertySet.InsertScalar("t0", 0F);
				// Layer aggregator
				result.Children.InsertAtTop(ShapeVisual_0());
				return result;
			}

			CubicBezierEasingFunction CubicBezierEasingFunction_0()
			{
				return (_cubicBezierEasingFunction_0 == null)
					? _cubicBezierEasingFunction_0 = _c.CreateCubicBezierEasingFunction(new Vector2(0.333000004F, 0F), new Vector2(0.666999996F, 1F))
					: _cubicBezierEasingFunction_0;
			}

			CubicBezierEasingFunction CubicBezierEasingFunction_1()
			{
				return (_cubicBezierEasingFunction_1 == null)
					? _cubicBezierEasingFunction_1 = _c.CreateCubicBezierEasingFunction(new Vector2(0.166999996F, 0.166999996F), new Vector2(0.833000004F, 0.833000004F))
					: _cubicBezierEasingFunction_1;
			}

			CubicBezierEasingFunction CubicBezierEasingFunction_2()
			{
				return (_cubicBezierEasingFunction_2 == null)
					? _cubicBezierEasingFunction_2 = _c.CreateCubicBezierEasingFunction(new Vector2(0.333000004F, 0.333000004F), new Vector2(0.666999996F, 0.666999996F))
					: _cubicBezierEasingFunction_2;
			}

			// - Layer aggregator
			// Rotation
			ScalarKeyFrameAnimation RotationAngleInDegreesScalarAnimation_0_to_0_0()
			{
				// Frame 0.
				var result = CreateScalarKeyFrameAnimation(0F, 0F, StepThenHoldEasingFunction());
				// Frame 3.
				result.InsertKeyFrame(0.107142858F, 0F, HoldThenStepEasingFunction());
				// Frame 5.
				result.InsertKeyFrame(0.178571433F, 4F, CubicBezierEasingFunction_0());
				// Frame 11.
				result.InsertKeyFrame(0.392857134F, 9F, CubicBezierEasingFunction_0());
				// Frame 18.
				result.InsertKeyFrame(0.642857134F, 9F, CubicBezierEasingFunction_1());
				// Frame 24.
				result.InsertKeyFrame(0.857142866F, 3F, CubicBezierEasingFunction_0());
				// Frame 26.
				result.InsertKeyFrame(0.928571403F, 0F, CubicBezierEasingFunction_0());
				return result;
			}

			// - Layer aggregator
			// Rotation
			ScalarKeyFrameAnimation RotationAngleInDegreesScalarAnimation_0_to_0_1()
			{
				// Frame 0.
				var result = CreateScalarKeyFrameAnimation(0F, 0F, StepThenHoldEasingFunction());
				// Frame 3.
				result.InsertKeyFrame(0.107142858F, 0F, HoldThenStepEasingFunction());
				// Frame 5.
				result.InsertKeyFrame(0.178571433F, 4F, CubicBezierEasingFunction_0());
				// Frame 11.
				result.InsertKeyFrame(0.392857134F, -7F, CubicBezierEasingFunction_0());
				// Frame 18.
				result.InsertKeyFrame(0.642857134F, -7F, CubicBezierEasingFunction_1());
				// Frame 24.
				result.InsertKeyFrame(0.857142866F, 3F, CubicBezierEasingFunction_0());
				// Frame 26.
				result.InsertKeyFrame(0.928571403F, 0F, CubicBezierEasingFunction_0());
				return result;
			}

			ScalarKeyFrameAnimation t0ScalarAnimation_0_to_1()
			{
				// Frame 24.
				var result = CreateScalarKeyFrameAnimation(0.857142925F, 0F, StepThenHoldEasingFunction());
				result.SetReferenceParameter("_", _root);
				// Frame 26.
				result.InsertKeyFrame(0.928571343F, 1F, CubicBezierEasingFunction_0());
				return result;
			}

			// Layer aggregator
			ShapeVisual ShapeVisual_0()
			{
				var result = _c.CreateShapeVisual();
				result.Size = new Vector2(48F, 48F);
				var shapes = result.Shapes;
				shapes.Add(ContainerShape_0());
				shapes.Add(ContainerShape_1());
				return result;
			}

			StepEasingFunction HoldThenStepEasingFunction()
			{
				if (_holdThenStepEasingFunction != null) { return _holdThenStepEasingFunction; }
				var result = _holdThenStepEasingFunction = _c.CreateStepEasingFunction();
				result.IsFinalStepSingleFrame = true;
				return result;
			}

			StepEasingFunction StepThenHoldEasingFunction()
			{
				if (_stepThenHoldEasingFunction != null) { return _stepThenHoldEasingFunction; }
				var result = _stepThenHoldEasingFunction = _c.CreateStepEasingFunction();
				result.IsInitialStepSingleFrame = true;
				return result;
			}

			// - Layer aggregator
			// Offset
			Vector2KeyFrameAnimation OffsetVector2Animation_0()
			{
				// Frame 0.
				var result = CreateVector2KeyFrameAnimation(0F, new Vector2(0F, 0F), StepThenHoldEasingFunction());
				// Frame 3.
				result.InsertKeyFrame(0.107142858F, new Vector2(0F, 0F), HoldThenStepEasingFunction());
				// Frame 5.
				result.InsertKeyFrame(0.178571433F, new Vector2(0F, 0F), CubicBezierEasingFunction_2());
				// Frame 11.
				result.InsertKeyFrame(0.392857134F, new Vector2(0F, 1F), CubicBezierEasingFunction_0());
				// Frame 18.
				result.InsertKeyFrame(0.642857134F, new Vector2(0F, 1F), CubicBezierEasingFunction_1());
				// Frame 24.
				result.InsertKeyFrame(0.857142866F, new Vector2(0F, 0F), CubicBezierEasingFunction_0());
				return result;
			}

			// - Layer aggregator
			// Offset
			Vector2KeyFrameAnimation OffsetVector2Animation_1()
			{
				// Frame 0.
				var result = CreateVector2KeyFrameAnimation(0F, new Vector2(0F, 0F), StepThenHoldEasingFunction());
				result.SetReferenceParameter("_", _root);
				// Frame 3.
				result.InsertKeyFrame(0.107142858F, new Vector2(0F, 0F), HoldThenStepEasingFunction());
				// Frame 5.
				result.InsertKeyFrame(0.178571433F, new Vector2(0F, 0F), CubicBezierEasingFunction_2());
				// Frame 11.
				result.InsertKeyFrame(0.392857134F, new Vector2(0F, -1F), CubicBezierEasingFunction_0());
				// Frame 18.
				result.InsertKeyFrame(0.642857134F, new Vector2(0F, -1F), CubicBezierEasingFunction_1());
				// Frame 24.
				result.InsertKeyFrame(0.857142866F, new Vector2(0F, 0F), CubicBezierEasingFunction_0());
				// Frame 26.
				result.InsertExpressionKeyFrame(0.928571343F, "3*Square(1-_.t0)*_.t0*Vector2(0,0.167)+(3*(1-_.t0)*Square(_.t0)*Vector2(0,-0.019))", StepThenHoldEasingFunction());
				// Frame 26.
				result.InsertKeyFrame(0.928571403F, new Vector2(0F, 0F), StepThenHoldEasingFunction());
				return result;
			}

			internal Honeymoon_AnimatedVisual(
				Compositor compositor
				)
			{
				_c = compositor;
				_reusableExpressionAnimation = compositor.CreateExpressionAnimation();
				Root();
			}

			public Visual RootVisual => _root;
			public TimeSpan Duration => TimeSpan.FromTicks(c_durationTicks);
			public Vector2 Size => new Vector2(48F, 48F);
			void IDisposable.Dispose() => _root?.Dispose();

			public void CreateAnimations()
			{
				_containerShape_0.StartAnimation("RotationAngleInDegrees", RotationAngleInDegreesScalarAnimation_0_to_0_0(), AnimationController_0());
				_containerShape_0.StartAnimation("Offset", OffsetVector2Animation_0(), AnimationController_0());
				_containerShape_1.StartAnimation("RotationAngleInDegrees", RotationAngleInDegreesScalarAnimation_0_to_0_1(), AnimationController_0());
				_containerShape_1.StartAnimation("Offset", OffsetVector2Animation_1(), AnimationController_0());
				_root.Properties.StartAnimation("t0", t0ScalarAnimation_0_to_1(), AnimationController_0());
			}

			public void DestroyAnimations()
			{
				_containerShape_0.StopAnimation("RotationAngleInDegrees");
				_containerShape_0.StopAnimation("Offset");
				_containerShape_1.StopAnimation("RotationAngleInDegrees");
				_containerShape_1.StopAnimation("Offset");
				_root.Properties.StopAnimation("t0");
			}

		}
	}
}
