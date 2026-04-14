using System.Text;
using KbsMobile.Core.Models;

namespace KbsMobile.Features.Map.Services;

public class MapBridgeService : IMapBridgeService
{
    public string BuildHtml(IEnumerable<WmsLayerDefinition> layers, double? latitude = null, double? longitude = null)
    {
        var serialized = System.Text.Json.JsonSerializer.Serialize(layers.OrderBy(x => x.Order));
        var lat = latitude ?? 41.015;
        var lon = longitude ?? 28.979;

        return $$"""
<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/ol@v9.1.0/ol.css" />
<script src="https://cdn.jsdelivr.net/npm/ol@v9.1.0/dist/ol.js"></script>
<style>html,body,#map{margin:0;padding:0;width:100%;height:100%;}.popup{background:#fff;padding:8px;border-radius:6px;}</style>
</head>
<body>
<div id="map"></div>
<script>
  const layers = {{serialized}};
  const base = new ol.layer.Tile({ source: new ol.source.OSM() });
  const overlays = layers.map(l => new ol.layer.Tile({
     visible: l.IsVisible,
     source: new ol.source.TileWMS({ url: l.Url, params: { LAYERS: l.LayerName, FORMAT: l.Format, TILED: true }, serverType: 'geoserver' })
  }));
  const view = new ol.View({ center: ol.proj.fromLonLat([{{lon}},{{lat}}]), zoom: 13 });
  const map = new ol.Map({ target:'map', layers:[base, ...overlays], view });

  window.toggleLayer = function(index, visible){ overlays[index].setVisible(visible); };
  window.focusTo = function(lat, lon){ view.animate({ center: ol.proj.fromLonLat([lon,lat]), zoom: 16, duration: 500 }); };
  map.on('singleclick', function(evt){
     const coordinate = ol.proj.toLonLat(evt.coordinate);
     window.location.href = `kbsmobile://mapclick?lon=${coordinate[0]}&lat=${coordinate[1]}`;
  });
</script>
</body></html>
""";
    }
}
