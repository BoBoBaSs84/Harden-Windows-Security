﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//       LottieGen version:
//           8.1.240821.1+077322fa26
//       
//       Command:
//           LottieGen -Language CSharp -Public -WinUIVersion 3.0 -InputFile Validate.json
//       
//       Input file:
//           Validate.json (144665 bytes created 10:21+02:00 Jan 3 2025)
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
// | All CompositionObjects   |   138 |
// |--------------------------+-------|
// | Expression animators     |     1 |
// | KeyFrame animators       |     4 |
// | Reference parameters     |     1 |
// | Expression operations    |     0 |
// |--------------------------+-------|
// | Animated brushes         |     - |
// | Animated gradient stops  |     - |
// | ExpressionAnimations     |     1 |
// | PathKeyFrameAnimations   |     1 |
// |--------------------------+-------|
// | ContainerVisuals         |     5 |
// | ShapeVisuals             |     6 |
// |--------------------------+-------|
// | ContainerShapes          |     1 |
// | CompositionSpriteShapes  |    14 |
// |--------------------------+-------|
// | Brushes                  |    15 |
// | Gradient stops           |     - |
// | CompositionVisualSurface |     4 |
// ------------------------------------
using Microsoft.Graphics;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.UI.Composition;
using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.UI;

namespace AnimatedVisuals
{
	// Name:        portrait-mode-scanning
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
	sealed partial class Validate
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
				new Validate_AnimatedVisual(
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

		sealed partial class Validate_AnimatedVisual
			: Microsoft.UI.Xaml.Controls.IAnimatedVisual
			, Microsoft.UI.Xaml.Controls.IAnimatedVisual2
		{
			const long c_durationTicks = 11666666;
			readonly Compositor _c;
			readonly ExpressionAnimation _reusableExpressionAnimation;
			AnimationController _animationController_0;
			CompositionColorBrush _colorBrush_AlmostLightCoral_FFE47373;
			CompositionColorBrush _colorBrush_AlmostPaleGreen_FF9FFFA2;
			CompositionColorBrush _colorBrush_AlmostRoyalBlue_FF1876D2;
			CompositionContainerShape _containerShape;
			CompositionPath _path_0;
			CompositionPath _path_1;
			CompositionPathGeometry _pathGeometry_3;
			CompositionPathGeometry _pathGeometry_4;
			CompositionPathGeometry _pathGeometry_7;
			ContainerVisual _root;
			CubicBezierEasingFunction _cubicBezierEasingFunction_0;
			CubicBezierEasingFunction _cubicBezierEasingFunction_1;
			ShapeVisual _shapeVisual_5;
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

			PathKeyFrameAnimation CreatePathKeyFrameAnimation(float initialProgress, CompositionPath initialValue, CompositionEasingFunction initialEasingFunction)
			{
				var result = _c.CreatePathKeyFrameAnimation();
				result.Duration = TimeSpan.FromTicks(c_durationTicks);
				result.InsertKeyFrame(initialProgress, initialValue, initialEasingFunction);
				return result;
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

			// - - - Shape tree root for layer: Frame 
			// - -  Offset:<-0.25, -0.25>
			CanvasGeometry Geometry_0()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(-24F, 13.3330002F));
					builder.AddLine(new Vector2(-24F, 24F));
					builder.AddLine(new Vector2(-13.3330002F, 24F));
					builder.AddLine(new Vector2(-13.3330002F, 20F));
					builder.AddLine(new Vector2(-20F, 20F));
					builder.AddLine(new Vector2(-20F, 13.3330002F));
					builder.AddLine(new Vector2(-24F, 13.3330002F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					builder.BeginFigure(new Vector2(20F, 13.3330002F));
					builder.AddLine(new Vector2(20F, 20F));
					builder.AddLine(new Vector2(13.3330002F, 20F));
					builder.AddLine(new Vector2(13.3330002F, 24F));
					builder.AddLine(new Vector2(24F, 24F));
					builder.AddLine(new Vector2(24F, 13.3330002F));
					builder.AddLine(new Vector2(20F, 13.3330002F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					builder.BeginFigure(new Vector2(-24F, -24F));
					builder.AddLine(new Vector2(-24F, -13.3339996F));
					builder.AddLine(new Vector2(-20F, -13.3339996F));
					builder.AddLine(new Vector2(-20F, -20F));
					builder.AddLine(new Vector2(-13.3330002F, -20F));
					builder.AddLine(new Vector2(-13.3330002F, -24F));
					builder.AddLine(new Vector2(-24F, -24F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					builder.BeginFigure(new Vector2(13.3330002F, -24F));
					builder.AddLine(new Vector2(13.3330002F, -20F));
					builder.AddLine(new Vector2(20F, -20F));
					builder.AddLine(new Vector2(20F, -13.3339996F));
					builder.AddLine(new Vector2(24F, -13.3339996F));
					builder.AddLine(new Vector2(24F, -24F));
					builder.AddLine(new Vector2(13.3330002F, -24F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			// - - - Shape tree root for layer: File 
			// - -  Offset:<10.416, 6.4160004>
			CanvasGeometry Geometry_1()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(13.3330002F, 17.3330002F));
					builder.AddLine(new Vector2(-13.3330002F, 17.3330002F));
					builder.AddLine(new Vector2(-13.3330002F, -17.3330002F));
					builder.AddLine(new Vector2(5.33300018F, -17.3330002F));
					builder.AddLine(new Vector2(13.3330002F, -9.33300018F));
					builder.AddLine(new Vector2(13.3330002F, 17.3330002F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			// - - - Shape tree root for layer: File 
			// - -  Offset:<10.416, 6.4160004>
			CanvasGeometry Geometry_2()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(3.33299994F, 3.33299994F));
					builder.AddLine(new Vector2(-3.33299994F, 3.33299994F));
					builder.AddLine(new Vector2(-3.33299994F, -3.33299994F));
					builder.AddLine(new Vector2(3.33299994F, 3.33299994F));
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
					builder.BeginFigure(new Vector2(-9.33300018F, -1.33299994F));
					builder.AddLine(new Vector2(9.33300018F, -1.33299994F));
					builder.AddLine(new Vector2(9.33300018F, 1.33299994F));
					builder.AddLine(new Vector2(-9.33300018F, 1.33299994F));
					builder.AddLine(new Vector2(-9.33300018F, -1.33299994F));
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
					builder.BeginFigure(new Vector2(-24F, 2.66700006F));
					builder.AddCubicBezier(new Vector2(-24F, 2.66700006F), new Vector2(24F, 2.66700006F), new Vector2(24F, 2.66700006F));
					builder.AddCubicBezier(new Vector2(24F, 2.66700006F), new Vector2(24F, -2.66700006F), new Vector2(24F, -2.66700006F));
					builder.AddCubicBezier(new Vector2(24F, -2.66700006F), new Vector2(-24F, -2.66700006F), new Vector2(-24F, -2.66700006F));
					builder.AddCubicBezier(new Vector2(-24F, -2.66700006F), new Vector2(-24F, 2.66700006F), new Vector2(-24F, 2.66700006F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			CanvasGeometry Geometry_5()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(-24F, 2.66700006F));
					builder.AddCubicBezier(new Vector2(-24F, 2.66700006F), new Vector2(24F, 2.66700006F), new Vector2(24F, 2.66700006F));
					builder.AddCubicBezier(new Vector2(24F, 2.66700006F), new Vector2(23.9880009F, -39.4169998F), new Vector2(23.9880009F, -39.4169998F));
					builder.AddCubicBezier(new Vector2(23.9880009F, -39.4169998F), new Vector2(-24.0119991F, -39.4169998F), new Vector2(-24.0119991F, -39.4169998F));
					builder.AddCubicBezier(new Vector2(-24.0119991F, -39.4169998F), new Vector2(-24F, 2.66700006F), new Vector2(-24F, 2.66700006F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			// - - - Opacity for layer: Red File 
			// - -  Offset:<10.448999, 6.450001>
			CanvasGeometry Geometry_6()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(13.2489996F, 17.2999992F));
					builder.AddLine(new Vector2(-13.3500004F, 17.2999992F));
					builder.AddLine(new Vector2(-13.3500004F, -17.2999992F));
					builder.AddLine(new Vector2(5.3499999F, -17.2999992F));
					builder.AddLine(new Vector2(13.3500004F, -9.30000019F));
					builder.AddLine(new Vector2(13.3500004F, 17.2999992F));
					builder.AddLine(new Vector2(13.2489996F, 17.2999992F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			// - - - Opacity for layer: Red File 
			// - -  Offset:<10.448999, 6.450001>
			CanvasGeometry Geometry_7()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(3.3499999F, 3.3499999F));
					builder.AddLine(new Vector2(-3.3499999F, 3.3499999F));
					builder.AddLine(new Vector2(-3.3499999F, -3.3499999F));
					builder.AddLine(new Vector2(3.3499999F, 3.3499999F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			CanvasGeometry Geometry_8()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(-9.35000038F, -1.35000002F));
					builder.AddLine(new Vector2(9.35000038F, -1.35000002F));
					builder.AddLine(new Vector2(9.35000038F, 1.35000002F));
					builder.AddLine(new Vector2(-9.35000038F, 1.35000002F));
					builder.AddLine(new Vector2(-9.35000038F, -1.35000002F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			// - - - - Opacity for layer: Line 
			// - - ShapeGroup: Group 1 Offset:<24.25, 1.584>
			CanvasGeometry Geometry_9()
			{
				CanvasGeometry result;
				using (var builder = new CanvasPathBuilder(null))
				{
					builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
					builder.BeginFigure(new Vector2(-24F, 1.33399999F));
					builder.AddLine(new Vector2(24F, 1.33399999F));
					builder.AddLine(new Vector2(24F, -1.64600003F));
					builder.AddLine(new Vector2(-24F, -1.64600003F));
					builder.AddLine(new Vector2(-24F, 1.33399999F));
					builder.EndFigure(CanvasFigureLoop.Closed);
					result = CanvasGeometry.CreatePath(builder);
				}
				return result;
			}

			// - Opacity for layer: Red File 
			// Offset:<10.448999, 6.450001>
			CompositionColorBrush ColorBrush_AlmostDarkSalmon_FFEE9A9A()
			{
				return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xEE, 0x9A, 0x9A));
			}

			CompositionColorBrush ColorBrush_AlmostLightCoral_FFE47373()
			{
				return (_colorBrush_AlmostLightCoral_FFE47373 == null)
					? _colorBrush_AlmostLightCoral_FFE47373 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xE4, 0x73, 0x73))
					: _colorBrush_AlmostLightCoral_FFE47373;
			}

			// - Shape tree root for layer: File 
			// Offset:<10.416, 6.4160004>
			CompositionColorBrush ColorBrush_AlmostLightCyan_FFE0F5FD()
			{
				return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xE0, 0xF5, 0xFD));
			}

			// - Shape tree root for layer: File 
			// Offset:<10.416, 6.4160004>
			CompositionColorBrush ColorBrush_AlmostLightSkyBlue_FF90C9F8()
			{
				return _c.CreateColorBrush(Color.FromArgb(0xFF, 0x90, 0xC9, 0xF8));
			}

			// - - Opacity for layer: Line 
			// ShapeGroup: Group 1 Offset:<24.25, 1.584>
			CompositionColorBrush ColorBrush_AlmostOrangeRed_FFFF3C00()
			{
				return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0x3C, 0x00));
			}

			CompositionColorBrush ColorBrush_AlmostPaleGreen_FF9FFFA2()
			{
				return (_colorBrush_AlmostPaleGreen_FF9FFFA2 == null)
					? _colorBrush_AlmostPaleGreen_FF9FFFA2 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x9F, 0xFF, 0xA2))
					: _colorBrush_AlmostPaleGreen_FF9FFFA2;
			}

			// - Opacity for layer: Red File 
			// Offset:<10.448999, 6.450001>
			CompositionColorBrush ColorBrush_AlmostPink_FFFFCDD2()
			{
				return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xCD, 0xD2));
			}

			CompositionColorBrush ColorBrush_AlmostRoyalBlue_FF1876D2()
			{
				return (_colorBrush_AlmostRoyalBlue_FF1876D2 == null)
					? _colorBrush_AlmostRoyalBlue_FF1876D2 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x18, 0x76, 0xD2))
					: _colorBrush_AlmostRoyalBlue_FF1876D2;
			}

			// - Shape tree root for layer: Frame 
			// Offset:<-0.25, -0.25>
			CompositionColorBrush ColorBrush_AlmostSilver_FFAFBDC5()
			{
				return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xAF, 0xBD, 0xC5));
			}

			// Opacity for layer: Line
			CompositionContainerShape ContainerShape()
			{
				if (_containerShape != null) { return _containerShape; }
				var result = _containerShape = _c.CreateContainerShape();
				result.CenterPoint = new Vector2(24.25F, 1.58399999F);
				// ShapeGroup: Group 1 Offset:<24.25, 1.584>
				result.Shapes.Add(SpriteShape_13());
				return result;
			}

			CompositionEffectBrush EffectBrush_0()
			{
				var effectFactory = EffectFactory_0();
				var result = effectFactory.CreateBrush();
				result.SetSourceParameter("destination", SurfaceBrush_0());
				result.SetSourceParameter("source", SurfaceBrush_1());
				return result;
			}

			CompositionEffectBrush EffectBrush_1()
			{
				var effectFactory = EffectFactory_1();
				var result = effectFactory.CreateBrush();
				result.SetSourceParameter("destination", SurfaceBrush_2());
				result.SetSourceParameter("source", SurfaceBrush_3());
				return result;
			}

			CompositionEffectFactory EffectFactory_0()
			{
				var compositeEffect = new CompositeEffect();
				compositeEffect.Mode = CanvasComposite.DestinationOut;
				compositeEffect.Sources.Add(new CompositionEffectSourceParameter("destination"));
				compositeEffect.Sources.Add(new CompositionEffectSourceParameter("source"));
				var result = _c.CreateEffectFactory(compositeEffect);
				return result;
			}

			CompositionEffectFactory EffectFactory_1()
			{
				var compositeEffect = new CompositeEffect();
				compositeEffect.Mode = CanvasComposite.DestinationIn;
				compositeEffect.Sources.Add(new CompositionEffectSourceParameter("destination"));
				compositeEffect.Sources.Add(new CompositionEffectSourceParameter("source"));
				var result = _c.CreateEffectFactory(compositeEffect);
				return result;
			}

			CompositionPath Path_0()
			{
				if (_path_0 != null) { return _path_0; }
				var result = _path_0 = new CompositionPath(Geometry_4());
				return result;
			}

			CompositionPath Path_1()
			{
				if (_path_1 != null) { return _path_1; }
				var result = _path_1 = new CompositionPath(Geometry_5());
				return result;
			}

			// - Shape tree root for layer: Frame 
			// Offset:<-0.25, -0.25>
			CompositionPathGeometry PathGeometry_0()
			{
				return _c.CreatePathGeometry(new CompositionPath(Geometry_0()));
			}

			// - Shape tree root for layer: File 
			// Offset:<10.416, 6.4160004>
			CompositionPathGeometry PathGeometry_1()
			{
				return _c.CreatePathGeometry(new CompositionPath(Geometry_1()));
			}

			// - Shape tree root for layer: File 
			// Offset:<10.416, 6.4160004>
			CompositionPathGeometry PathGeometry_2()
			{
				return _c.CreatePathGeometry(new CompositionPath(Geometry_2()));
			}

			CompositionPathGeometry PathGeometry_3()
			{
				return (_pathGeometry_3 == null)
					? _pathGeometry_3 = _c.CreatePathGeometry(new CompositionPath(Geometry_3()))
					: _pathGeometry_3;
			}

			CompositionPathGeometry PathGeometry_4()
			{
				if (_pathGeometry_4 != null) { return _pathGeometry_4; }
				var result = _pathGeometry_4 = _c.CreatePathGeometry();
				return result;
			}

			// - Opacity for layer: Red File 
			// Offset:<10.448999, 6.450001>
			CompositionPathGeometry PathGeometry_5()
			{
				return _c.CreatePathGeometry(new CompositionPath(Geometry_6()));
			}

			// - Opacity for layer: Red File 
			// Offset:<10.448999, 6.450001>
			CompositionPathGeometry PathGeometry_6()
			{
				return _c.CreatePathGeometry(new CompositionPath(Geometry_7()));
			}

			CompositionPathGeometry PathGeometry_7()
			{
				return (_pathGeometry_7 == null)
					? _pathGeometry_7 = _c.CreatePathGeometry(new CompositionPath(Geometry_8()))
					: _pathGeometry_7;
			}

			// - - Opacity for layer: Line 
			// ShapeGroup: Group 1 Offset:<24.25, 1.584>
			CompositionPathGeometry PathGeometry_8()
			{
				return _c.CreatePathGeometry(new CompositionPath(Geometry_9()));
			}

			// Shape tree root for layer: Frame 
			// ShapeGroup: Group 1 Offset:<24.25, 24.25>
			CompositionSpriteShape SpriteShape_00()
			{
				// Offset:<24, 24>
				var geometry = PathGeometry_0();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24F, 24F), ColorBrush_AlmostSilver_FFAFBDC5()); ;
				return result;
			}

			// Shape tree root for layer: File 
			// Path 1
			CompositionSpriteShape SpriteShape_01()
			{
				// Offset:<23.999, 23.999>
				var geometry = PathGeometry_1();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.9990005F, 23.9990005F), ColorBrush_AlmostLightSkyBlue_FF90C9F8()); ;
				return result;
			}

			// Shape tree root for layer: File 
			// Path 1
			CompositionSpriteShape SpriteShape_02()
			{
				// Offset:<31.333, 12.666>
				var geometry = PathGeometry_2();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 31.3330002F, 12.6660004F), ColorBrush_AlmostLightCyan_FFE0F5FD()); ;
				return result;
			}

			// Shape tree root for layer: File 
			// Path 1
			CompositionSpriteShape SpriteShape_03()
			{
				// Offset:<24, 20>
				var geometry = PathGeometry_3();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24F, 20F), ColorBrush_AlmostRoyalBlue_FF1876D2()); ;
				return result;
			}

			// Shape tree root for layer: File 
			// Path 1
			CompositionSpriteShape SpriteShape_04()
			{
				// Offset:<24, 25.333>
				var geometry = PathGeometry_3();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24F, 25.3330002F), ColorBrush_AlmostRoyalBlue_FF1876D2()); ;
				return result;
			}

			// Shape tree root for layer: File 
			// Path 1
			CompositionSpriteShape SpriteShape_05()
			{
				// Offset:<24, 30.666>
				var geometry = PathGeometry_3();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24F, 30.6660004F), ColorBrush_AlmostRoyalBlue_FF1876D2()); ;
				return result;
			}

			// Shape tree root for layer: File  Mask
			// Path 1
			CompositionSpriteShape SpriteShape_06()
			{
				// Offset:<24, 45.333>, Scale:<1.05, 1>
				var geometry = PathGeometry_4();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1.04999995F, 0F, 0F, 1F, 24F, 45.3330002F), ColorBrush_AlmostPaleGreen_FF9FFFA2()); ;
				return result;
			}

			// Opacity for layer: Red File 
			// Path 1
			CompositionSpriteShape SpriteShape_07()
			{
				// Offset:<24.05, 24>
				var geometry = PathGeometry_5();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24.0499992F, 24F), ColorBrush_AlmostPink_FFFFCDD2()); ;
				return result;
			}

			// Opacity for layer: Red File 
			// Path 1
			CompositionSpriteShape SpriteShape_08()
			{
				// Offset:<31.348999, 12.650001>
				var geometry = PathGeometry_6();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 31.348999F, 12.6500006F), ColorBrush_AlmostDarkSalmon_FFEE9A9A()); ;
				return result;
			}

			// Opacity for layer: Red File 
			// Path 1
			CompositionSpriteShape SpriteShape_09()
			{
				// Offset:<24.049, 20.050001>
				var geometry = PathGeometry_7();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24.0489998F, 20.0500011F), ColorBrush_AlmostLightCoral_FFE47373()); ;
				return result;
			}

			// Opacity for layer: Red File 
			// Path 1
			CompositionSpriteShape SpriteShape_10()
			{
				// Offset:<24.049, 25.35>
				var geometry = PathGeometry_7();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24.0489998F, 25.3500004F), ColorBrush_AlmostLightCoral_FFE47373()); ;
				return result;
			}

			// Opacity for layer: Red File 
			// Path 1
			CompositionSpriteShape SpriteShape_11()
			{
				// Offset:<24.049, 30.650002>
				var geometry = PathGeometry_7();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24.0489998F, 30.6500015F), ColorBrush_AlmostLightCoral_FFE47373()); ;
				return result;
			}

			// Shape tree root for layer: Red File  Mask
			// Path 1
			CompositionSpriteShape SpriteShape_12()
			{
				// Offset:<24, 45.333>, Scale:<1.05, 1>
				var geometry = PathGeometry_4();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1.04999995F, 0F, 0F, 1F, 24F, 45.3330002F), ColorBrush_AlmostPaleGreen_FF9FFFA2()); ;
				return result;
			}

			// - Opacity for layer: Line 
			// Path 1
			CompositionSpriteShape SpriteShape_13()
			{
				// Offset:<24.25, 1.584>
				var geometry = PathGeometry_8();
				var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 24.25F, 1.58399999F), ColorBrush_AlmostOrangeRed_FFFF3C00()); ;
				return result;
			}

			CompositionSurfaceBrush SurfaceBrush_0()
			{
				return _c.CreateSurfaceBrush(VisualSurface_0());
			}

			CompositionSurfaceBrush SurfaceBrush_1()
			{
				return _c.CreateSurfaceBrush(VisualSurface_1());
			}

			CompositionSurfaceBrush SurfaceBrush_2()
			{
				return _c.CreateSurfaceBrush(VisualSurface_2());
			}

			CompositionSurfaceBrush SurfaceBrush_3()
			{
				return _c.CreateSurfaceBrush(VisualSurface_3());
			}

			CompositionVisualSurface VisualSurface_0()
			{
				var result = _c.CreateVisualSurface();
				result.SourceVisual = ContainerVisual_0();
				result.SourceSize = new Vector2(48F, 48F);
				return result;
			}

			CompositionVisualSurface VisualSurface_1()
			{
				var result = _c.CreateVisualSurface();
				result.SourceVisual = ContainerVisual_1();
				result.SourceSize = new Vector2(48F, 48F);
				return result;
			}

			CompositionVisualSurface VisualSurface_2()
			{
				var result = _c.CreateVisualSurface();
				result.SourceVisual = ContainerVisual_2();
				result.SourceSize = new Vector2(48F, 48F);
				return result;
			}

			CompositionVisualSurface VisualSurface_3()
			{
				var result = _c.CreateVisualSurface();
				result.SourceVisual = ContainerVisual_3();
				result.SourceSize = new Vector2(48F, 48F);
				return result;
			}

			ContainerVisual ContainerVisual_0()
			{
				var result = _c.CreateContainerVisual();
				result.BorderMode = CompositionBorderMode.Soft;
				// Shape tree root for layer: File
				result.Children.InsertAtTop(ShapeVisual_1());
				return result;
			}

			ContainerVisual ContainerVisual_1()
			{
				var result = _c.CreateContainerVisual();
				result.BorderMode = CompositionBorderMode.Soft;
				// Shape tree root for layer: File  Mask
				result.Children.InsertAtTop(ShapeVisual_2());
				return result;
			}

			ContainerVisual ContainerVisual_2()
			{
				var result = _c.CreateContainerVisual();
				result.BorderMode = CompositionBorderMode.Soft;
				// Opacity for layer: Red File
				result.Children.InsertAtTop(ShapeVisual_3());
				return result;
			}

			ContainerVisual ContainerVisual_3()
			{
				var result = _c.CreateContainerVisual();
				result.BorderMode = CompositionBorderMode.Soft;
				// Shape tree root for layer: Red File  Mask
				result.Children.InsertAtTop(ShapeVisual_4());
				return result;
			}

			// The root of the composition.
			ContainerVisual Root()
			{
				if (_root != null) { return _root; }
				var result = _root = _c.CreateContainerVisual();
				var propertySet = result.Properties;
				propertySet.InsertScalar("Progress", 0F);
				var children = result.Children;
				// Shape tree root for layer: Frame
				children.InsertAtTop(ShapeVisual_0());
				children.InsertAtTop(SpriteVisual_0());
				children.InsertAtTop(SpriteVisual_1());
				// Opacity for layer: Line
				children.InsertAtTop(ShapeVisual_5());
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

			// Path
			PathKeyFrameAnimation PathKeyFrameAnimation_0()
			{
				// Frame 0.
				var result = CreatePathKeyFrameAnimation(0F, Path_0(), StepThenHoldEasingFunction());
				// Frame 6.
				result.InsertKeyFrame(0.214285716F, Path_0(), HoldThenStepEasingFunction());
				// Frame 12.
				result.InsertKeyFrame(0.428571433F, Path_1(), CubicBezierEasingFunction_0());
				// Frame 17.
				result.InsertKeyFrame(0.607142866F, Path_1(), CubicBezierEasingFunction_0());
				// Frame 23.
				result.InsertKeyFrame(0.821428597F, Path_0(), CubicBezierEasingFunction_0());
				return result;
			}

			// Opacity for layer: Line 
			// Layer opacity animation
			ScalarKeyFrameAnimation OpacityScalarAnimation_0_to_0()
			{
				// Frame 0.
				var result = CreateScalarKeyFrameAnimation(0F, 0F, StepThenHoldEasingFunction());
				// Frame 3.
				result.InsertKeyFrame(0.107142858F, 0F, HoldThenStepEasingFunction());
				// Frame 6.
				result.InsertKeyFrame(0.214285716F, 1F, CubicBezierEasingFunction_1());
				// Frame 23.
				result.InsertKeyFrame(0.821428597F, 1F, CubicBezierEasingFunction_1());
				// Frame 26.
				result.InsertKeyFrame(0.928571403F, 0F, CubicBezierEasingFunction_1());
				return result;
			}

			// Shape tree root for layer: Frame
			ShapeVisual ShapeVisual_0()
			{
				var result = _c.CreateShapeVisual();
				result.Size = new Vector2(48F, 48F);
				// Offset:<-0.25, -0.25>
				result.Shapes.Add(SpriteShape_00());
				return result;
			}

			// Shape tree root for layer: File
			ShapeVisual ShapeVisual_1()
			{
				var result = _c.CreateShapeVisual();
				result.Size = new Vector2(48F, 48F);
				var shapes = result.Shapes;
				// Offset:<10.416, 6.4160004>
				shapes.Add(SpriteShape_01());
				// Offset:<10.416, 6.4160004>
				shapes.Add(SpriteShape_02());
				// Offset:<10.416, 6.4160004>
				shapes.Add(SpriteShape_03());
				// Offset:<10.416, 6.4160004>
				shapes.Add(SpriteShape_04());
				// Offset:<10.416, 6.4160004>
				shapes.Add(SpriteShape_05());
				return result;
			}

			// Shape tree root for layer: File  Mask
			ShapeVisual ShapeVisual_2()
			{
				var result = _c.CreateShapeVisual();
				result.Size = new Vector2(48F, 48F);
				// Scale:1.05,1, Offset:<-0.25, 42.416>
				result.Shapes.Add(SpriteShape_06());
				return result;
			}

			// Shape tree root for layer: Red File
			ShapeVisual ShapeVisual_3()
			{
				var result = _c.CreateShapeVisual();
				result.Opacity = 0.99000001F;
				result.Size = new Vector2(48F, 48F);
				var shapes = result.Shapes;
				// Offset:<10.448999, 6.450001>
				shapes.Add(SpriteShape_07());
				// Offset:<10.448999, 6.450001>
				shapes.Add(SpriteShape_08());
				// Offset:<10.448999, 6.450001>
				shapes.Add(SpriteShape_09());
				// Offset:<10.448999, 6.450001>
				shapes.Add(SpriteShape_10());
				// Offset:<10.448999, 6.450001>
				shapes.Add(SpriteShape_11());
				return result;
			}

			// Shape tree root for layer: Red File  Mask
			ShapeVisual ShapeVisual_4()
			{
				var result = _c.CreateShapeVisual();
				result.Size = new Vector2(48F, 48F);
				// Scale:1.05,1, Offset:<-0.25, 42.416>
				result.Shapes.Add(SpriteShape_12());
				return result;
			}

			// Shape tree root for layer: Line
			ShapeVisual ShapeVisual_5()
			{
				if (_shapeVisual_5 != null) { return _shapeVisual_5; }
				var result = _shapeVisual_5 = _c.CreateShapeVisual();
				result.Size = new Vector2(48F, 48F);
				result.Shapes.Add(ContainerShape());
				return result;
			}

			SpriteVisual SpriteVisual_0()
			{
				var result = _c.CreateSpriteVisual();
				result.Size = new Vector2(48F, 48F);
				result.Brush = EffectBrush_0();
				return result;
			}

			SpriteVisual SpriteVisual_1()
			{
				var result = _c.CreateSpriteVisual();
				result.Size = new Vector2(48F, 48F);
				result.Brush = EffectBrush_1();
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

			// - Opacity for layer: Line 
			// Offset
			Vector2KeyFrameAnimation OffsetVector2Animation()
			{
				// Frame 0.
				var result = CreateVector2KeyFrameAnimation(0F, new Vector2(-0.25F, 41.0820007F), StepThenHoldEasingFunction());
				// Frame 6.
				result.InsertKeyFrame(0.214285716F, new Vector2(-0.25F, 41.0820007F), HoldThenStepEasingFunction());
				// Frame 12.
				result.InsertKeyFrame(0.428571433F, new Vector2(-0.25F, 4.06599998F), CubicBezierEasingFunction_0());
				// Frame 17.
				result.InsertKeyFrame(0.607142866F, new Vector2(-0.25F, 4.06599998F), _c.CreateCubicBezierEasingFunction(new Vector2(0.333000004F, 0.333000004F), new Vector2(0.666999996F, 0.666999996F)));
				// Frame 23.
				result.InsertKeyFrame(0.821428597F, new Vector2(-0.25F, 41.0820007F), CubicBezierEasingFunction_0());
				return result;
			}

			// - Opacity for layer: Line 
			// Scale
			Vector2KeyFrameAnimation ScaleVector2Animation()
			{
				// Frame 0.
				var result = CreateVector2KeyFrameAnimation(0F, new Vector2(0F, 1F), StepThenHoldEasingFunction());
				// Frame 3.
				result.InsertKeyFrame(0.107142858F, new Vector2(0F, 1F), HoldThenStepEasingFunction());
				// Frame 7.
				result.InsertKeyFrame(0.25F, new Vector2(1F, 1F), CubicBezierEasingFunction_0());
				// Frame 22.
				result.InsertKeyFrame(0.785714269F, new Vector2(1F, 1F), CubicBezierEasingFunction_1());
				// Frame 26.
				result.InsertKeyFrame(0.928571403F, new Vector2(0F, 1F), CubicBezierEasingFunction_0());
				return result;
			}

			internal Validate_AnimatedVisual(
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
				_containerShape.StartAnimation("Scale", ScaleVector2Animation(), AnimationController_0());
				_containerShape.StartAnimation("Offset", OffsetVector2Animation(), AnimationController_0());
				_pathGeometry_4.StartAnimation("Path", PathKeyFrameAnimation_0(), AnimationController_0());
				_shapeVisual_5.StartAnimation("Opacity", OpacityScalarAnimation_0_to_0(), AnimationController_0());
			}

			public void DestroyAnimations()
			{
				_containerShape.StopAnimation("Scale");
				_containerShape.StopAnimation("Offset");
				_pathGeometry_4.StopAnimation("Path");
				_shapeVisual_5.StopAnimation("Opacity");
			}

		}
	}
}
