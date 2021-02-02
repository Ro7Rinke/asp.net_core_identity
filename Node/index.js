const fs = require('fs')
const geohasher = require('ngeohash')

const main = async () => {
    

    const lat = -21.9743783494791
    const lon = -46.76374677428059

    const hash = geohasher.encode(lat, lon, 14)
    const neighbors_hashs = geohasher.neighbors(hash)

    console.log([hash, ...neighbors_hashs])


    
    return
    
    
    const georesp = JSON.parse(fs.readFileSync('./geocoderesponse.json'))
    let postal_code = extractPostalCode(georesp)

    console.log(postal_code)
}

const extractPostalCode = (georesp) => {
    if(Array.isArray(georesp.results))
        for(const result of georesp.results)
            if(Array.isArray(result.address_components))
                for(const address_component of result.address_components)
                    if(Array.isArray(address_component.types))
                        for(const type of address_component.types)
                            if(type == 'postal_code')
                                return address_component.long_name
    return null
}

main() 