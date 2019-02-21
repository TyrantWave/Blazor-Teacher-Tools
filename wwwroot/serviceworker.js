console.log("This is service worker talking!");
var cacheName = 'teacher-tools';
var filesToCache = [
    './',
    //Html and css files
    './index.html',
    './css/site.css',
    './css/bootstrap/bootstrap.min.css',
    './css/open-iconic/font/css/open-iconic-bootstrap.min.css',
    './css/open-iconic/font/fonts/open-iconic.woff',
    //Blazor framework
    './_framework/blazor.webassembly.js',
    './_framework/blazor.boot.json',
    //Our additional files
    './manifest.json',
    './serviceworker.js',
    './android-chrome-192x192.png',
    './android-chrome-512x512.png',
    './favicon-32x32.png',
    './favicon-16x16.png',
    //The web assembly/.net dll's
    './_content/Blazor.Extensions.Storage.JS',
    './_framework/wasm/mono.js',
    './_framework/wasm/mono.wasm',
    './_framework/_bin/Microsoft.AspNetCore.Blazor.Browser.dll',
    './_framework/_bin/Microsoft.AspNetCore.Blazor.dll',
    './_framework/_bin/Microsoft.Extensions.DependencyInjection.Abstractions.dll',
    './_framework/_bin/Microsoft.Extensions.DependencyInjection.dll',
    './_framework/_bin/Microsoft.JSInterop.dll',
    './_framework/_bin/mscorlib.dll',
    './_framework/_bin/System.Net.Http.dll',
    './_framework/_bin/Mono.WebAssembly.Interop.dll',
    './_framework/_bin/Mono.Security.dll',
    './_framework/_bin/System.dll',
    './_framework/_bin/System.Core.dll',
    './_framework/_bin/System.Web.Services.dll',
    './_framework/_bin/System.Transactions.dll',
    './_framework/_bin/System.Runtime.Serialization.dll',
    './_framework/_bin/System.ServiceModel.Internals.dll',
    './_framework/_bin/System.Numerics.dll',
    './_framework/_bin/System.ComponentModel.Composition.dll',
    './_framework/_bin/System.IO.Compression.FileSystem.dll',
    './_framework/_bin/System.IO.Compression.dll',
    './_framework/_bin/System.Drawing.dll',
    './_framework/_bin/System.Data.dll',
    './_framework/_bin/Newtonsoft.Json.dll',
    './_framework/_bin/netstandard.dll',
    './_framework/_bin/System.Xml.Linq.dll',
    './_framework/_bin/System.Xml.dll',
    './_framework/_bin/Blazor.Extensions.Storage.dll',
    //The compiled project .dll's
    './_framework/_bin/TeacherTools.dll'
];

self.addEventListener('install', function (e) {
    console.log('[ServiceWorker] Install');
    e.waitUntil(
        caches.open(cacheName).then(function (cache) {
            console.log('[ServiceWorker] Caching app shell');
            return cache.addAll(filesToCache);
        })
    );
});

self.addEventListener('activate', event => {
    event.waitUntil(self.clients.claim());
});

self.addEventListener('fetch', event => {
    event.respondWith(
        caches.match(event.request, {
            ignoreSearch: true
        }).then(response => {
            return response || fetch(event.request);
        })
    );
});