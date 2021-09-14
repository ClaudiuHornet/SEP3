package dk.via.sep3.group1.applicationlogic.shared;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;

public class Serialization {

    private static ObjectMapper objectMapper = new ObjectMapper();

    public static <T> String serialize(T objectToSerialize){
        String serializedString = "";
        try {
            serializedString = objectMapper.writeValueAsString(objectToSerialize);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        return serializedString;
    }


    public static  <T> T deserialize(String objectToDeserialize, Class<T> tClass){
        T object = null;
        try {

            object = objectMapper.readValue(objectToDeserialize, tClass);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        return object;
    }
}
