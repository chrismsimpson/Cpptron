/*
 * Copyright (c) 2018-2021, Andreas Kling <kling@serenityos.org>
 * Copyright (c) 2021, Daniel Bertalan <dani@danielbertalan.dev>
 *
 * SPDX-License-Identifier: BSD-2-Clause
 */

#pragma once

#include <Core/Checked.h>

#if defined(KERNEL)
#    include <Kernel/Heap/kmalloc.h>
#else
#    include <new>
#    include <stdlib.h>

#    define kcalloc calloc
#    define kmalloc malloc
#    define kmallocGoodSize malloc_good_size

inline void kfreeSized(void* ptr, size_t) {

    free(ptr);
}

#endif

#ifndef __os__
#    include <Core/Types.h>

#    ifndef OS_MACOS
extern "C" {
inline size_t malloc_good_size(size_t size) { return size; }
}
#    else
#        include <malloc/malloc.h>
#    endif
#endif

using std::nothrow;


inline void* kmallocArray(Checked<size_t> a, Checked<size_t> b) {

    auto size = a * b;
    
    VERIFY(!size.hasOverflow());
    
    return kmalloc(size.value());
}

inline void* kmallocArray(Checked<size_t> a, Checked<size_t> b, Checked<size_t> c) {

    auto size = a * b * c;
    
    VERIFY(!size.hasOverflow());
    
    return kmalloc(size.value());
}
