@echo off
msbuild Bootstrapper.Common.build /p:"Configuration=Release" /verbosity:minimal %*