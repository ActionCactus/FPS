# Unity Burst Compiler
.NET -> native machine code compilation done through LLVM.

# General Notes
* Intended to be used with the Jobs system
* `[BurstCompile]` on a job struct to invoke
* Use menu at `Jobs -> Burst Inspector` to view the disassembly for a Job compilation
* Uses JIT in the editor, but AOT when building a project for a particular platform.
* Only allows non-heap-allocated data types

# Optimization Guidelines
* Loop Vectorization
  * Can use `Unity.Burst.CompilerServices.Loop.ExpectVectorized()` in code to add a compile time check on loops which are supposed to be high-performance and will slow down if not vectorized
  * Vectorization occurs when there aren't branching paths in the loop so the compiler can run multiple iterations in parallel
  * Branching paths breaks ^ because the system can't predict the operations for the next loop iteration
* Compiler Options
  * Specify accuracy of math functions
  * Allow compiler to re-arrange floating point calculations by relaxing order of math computations
  * Forcing synchronous compilation of the job (only for the Unity Editor)
  * Specifying floating point precision with the `FloatPrecision` enum